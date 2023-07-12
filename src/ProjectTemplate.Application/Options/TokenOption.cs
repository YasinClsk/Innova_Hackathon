using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Options
{
    public class TokenOption
    {
        public String Issuer { get; set; } = string.Empty;
        public String Audience { get; set; } = string.Empty;
        public String Key { get; set; } = string.Empty;
    }
}
