using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTO_s
{
    public class UserCharges
    {
        public int Id { get; set; }
        public String Title { get; set; } = String.Empty;
        public decimal Cost { get; set; }
    }
}
