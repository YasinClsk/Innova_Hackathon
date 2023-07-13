using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Features.Commands.AuthCommands.LoginCommand;
using ProjectTemplate.Application.Features.Commands.AuthCommands.RegisterCommand;
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
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            var token = await _sender.Send(loginCommandRequest);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
        {
            var token = await _sender.Send(registerCommandRequest);
            return Ok(token);
        }
    }
}
