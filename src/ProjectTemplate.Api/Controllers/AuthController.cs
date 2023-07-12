using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Features.Commands.AuthCommands.LoginCommand;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.Infrastructure.Token;


namespace ProjectTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var token = await _sender.Send(new LoginCommandRequest(loginDTO.Email,loginDTO.Password));
            return Ok(token);
        }
    }
}
