﻿using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Api.Extensions;
using ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser;
using ProjectTemplate.Application.Features.Queries.UserQueries.GetByIdUser;

namespace ProjectTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<UsersController> _logger;
        public UsersController(ISender sender, ILogger<UsersController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserCommandResponse),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationErrorModel>),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CreateUserCommandRequest request)
        {
            var response = await _sender.Send(request);

            _logger.Log(LogLevel.Error, "{@Mail} adresiyle kullancı kayıt olmuştur",request.Email);
            return CreatedAtAction(nameof(Get), new { Id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _sender.Send(new GetByIdProductQueryRequest(id));
            _logger.Log(LogLevel.Error, "{@Id} kullanıcı getirilmiştir", id);

            return Ok(response);
        }
    }
}