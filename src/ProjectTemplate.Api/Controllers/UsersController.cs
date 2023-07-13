using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Api.Extensions;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser;
using ProjectTemplate.Application.Features.Commands.UserCommands.DeleteUser;
using ProjectTemplate.Application.Features.Commands.UserCommands.UpdateUser;
using ProjectTemplate.Application.Features.Queries.UserChargeQueries.GetUserCharge;
using ProjectTemplate.Application.Features.Queries.UserQueries.GetByIdUser;
using ProjectTemplate.Domain.Enums;

namespace ProjectTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;
        public UsersController(ISender sender, ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _sender = sender;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserCommandResponse),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationErrorModel>),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CreateUserCommandRequest request)
        {
            var response = await _sender.Send(request);
            return CreatedAtAction(nameof(Get), new { Id = response.Id }, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetByIdUserQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _sender.Send(new GetByIdUserQueryRequest(id));
            return Ok(response);
        }

        [HttpGet("{id}/charges")]
        [ProducesResponseType(typeof(List<UserCharges>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCharges(int id)
        {
            var response = await _userRepository.UserCharges(id);
            return Ok(response);
        }

        [HttpGet("{userId}/summary")]
        [ProducesResponseType(typeof(GetUsersChargeQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSummary([FromRoute]int userId, [
            FromQuery]ChargeInterval intervalType)
        {
            var response = await _sender.Send(new GetUsersChargeQueryRequest(userId, intervalType));
            return Ok(response);
        }

        [HttpPut("/update")]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(UpdateUserCommandRequest request)
        {
            _ = await _sender.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}/remove")]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            _ = await _sender.Send(new DeleteUserCommandRequest(id));
            return NoContent();
        }
    }
}
