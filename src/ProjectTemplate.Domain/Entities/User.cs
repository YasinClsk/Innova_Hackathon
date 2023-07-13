using ProjectTemplate.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Entities
{
    public class User : BaseEntity
    {
        public String Email { get; set; } = null!;
        public String Password { get; set; } = null!;
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;

        public ICollection<TransactionType> TransactionTypes { get; set; } = null!;
        public ICollection<UserCharge> UserCharges { get; set; } = null!;
    }
}
