using ProjectTemplate.Domain.Entities.Common;
using ProjectTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Entities
{
    public class UserCharge : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public decimal Cost { get; set; }
        public ChargeInterval ChargeInterval { get; set; }
    }
}
