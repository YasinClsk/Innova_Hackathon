using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTO_s
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public String Email { get; set; } = null!;
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
    }
}
