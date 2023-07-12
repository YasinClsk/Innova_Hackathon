using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTO_s
{
    public class TransactionTypeDTO
    {
        public List<TransactionDTO> Transactions { get; set; } = null!;
        public String Title { get; set; } = null!;
        public String Description { get; set; } = null!;
    }
}
