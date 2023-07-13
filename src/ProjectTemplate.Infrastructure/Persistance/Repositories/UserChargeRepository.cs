using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await Table.AddAsync(userCharge);
        }

        public async Task<UserCharge?> GetAsync(int userId, ChargeInterval chargeInterval = ChargeInterval.Daily)
        {
            var charge = await Table
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ChargeInterval == chargeInterval);

            return charge;
        }
    }
}
