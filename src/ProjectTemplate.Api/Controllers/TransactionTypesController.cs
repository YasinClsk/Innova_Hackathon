using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.DeleteTransaction;
using ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType;
using ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.DeleteTransactionType;
using ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.UpdateTransactionType;
using ProjectTemplate.Application.Features.Queries.TransactionTypeQueries.GetByIdTransactionType;
using ProjectTemplate.Application.RequestParameters;

namespace ProjectTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionTypesController : ControllerBase
    {
        private readonly ISender _sender;

        public TransactionTypesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionTypeCommandRequest request)
        {
            var response = await _sender.Send(request);
            return CreatedAtAction(nameof(Get),new {Id = response.Id},response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] Pagination pagination)
        {
            var response = await _sender.Send(new GetByIdTransactionTypeQueryRequest(id,pagination));
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]UpdateTransactionTypeCommandRequest request)
        {
            var response = await _sender.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _sender.Send(new DeleteTransactionTypeCommandRequest(id));
            return NoContent();
        }
    }
}
