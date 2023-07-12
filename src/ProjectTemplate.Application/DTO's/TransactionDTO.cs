using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTO_s
{
    public class TransactionDTO
    {
        public decimal Cost { get; set; }
        public String Name { get; set; } = null!;
        public String Description { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
    }
}
