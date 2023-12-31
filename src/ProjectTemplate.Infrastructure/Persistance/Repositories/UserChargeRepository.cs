﻿using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Persistance.Repositories
{
    public class UserChargeRepository : IUserChargeRepository
    {
        private readonly ApplicationDbContext _context;

        public UserChargeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private DbSet<UserCharge> Table => _context.UserCharges;

        public async Task CreateAsync(UserCharge userCharge)
        {
            var charge = await Table.FirstOrDefaultAsync(x => x.UserId == userCharge.UserId && userCharge.ChargeInterval == ChargeInterval.Daily);

            await Table.AddAsync(userCharge);
        }

        public async Task<UserCharge?> GetAsync(int userId, DateTime date,
            ChargeInterval chargeInterval = ChargeInterval.Daily)
        {
            var charge = await Table.OrderByDescending(x => x.CreatedDate)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ChargeInterval == chargeInterval && 
                x.StartDate <= date && x.EndDate >= date);

            return charge;
        }
    }
}
