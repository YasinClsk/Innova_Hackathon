using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Options;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Infrastructure.Token
{
    public class TokenHandler
    {
        private readonly TokenOption TokenOption;
        public TokenHandler(IOptions<TokenOption> options)
        {
            TokenOption = options.Value;
        }
        public string CreateToken(LoginDTO login)
        {
            var issuer = TokenOption.Issuer;
            var audience = TokenOption.Audience;
            var key = Encoding.ASCII.GetBytes(TokenOption.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", login.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, login.Email),
                    new Claim(JwtRegisteredClaimNames.GivenName, login.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, login.LastName),
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
