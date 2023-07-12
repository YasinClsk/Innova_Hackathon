using ProjectTemplate.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Abstractions.Handlers
{
    public interface ITokenHandler
    {
        string CreateToken(TokenDTO tokenDTO);
    }
}
