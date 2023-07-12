using ProjectTemplate.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Cost { get; set; }
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public DateTime TransactionDate { get; set; }

        public TransactionType TransactionType { get; set; } = null!;
    }
}
