using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.Infrastructure.Token;


namespace ProjectTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenHandler _tokenHandler;

        public AuthController(TokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }
        
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var token = _tokenHandler.CreateToken(loginDTO);
            return Ok(token);
        }
    }
}
