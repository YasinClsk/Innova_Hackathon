using ProjectTemplate.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Entities
{
    public class TransactionType : BaseEntity
    {
        public String Title { get; set; } = null!;
        public String Description { get; set; } = null!;
        public int UserId { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
