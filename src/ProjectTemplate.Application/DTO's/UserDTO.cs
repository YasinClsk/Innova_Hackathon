using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTO_s
{
    public class UserDTO
    {
        public String Email { get; set; } = null!;
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
        public List<TransactionTypeDTO> TransactionTypes { get; set; } = new();
    }
}
