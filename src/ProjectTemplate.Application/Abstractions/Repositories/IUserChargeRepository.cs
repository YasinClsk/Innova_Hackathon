using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Abstractions.Repositories
{
    public interface IUserChargeRepository
    {
        Task CreateAsync(UserCharge userCharge);
        Task<UserCharge?> GetAsync(int userId, DateTime date,ChargeInterval chargeInterval = ChargeInterval.Daily);
    }
}
