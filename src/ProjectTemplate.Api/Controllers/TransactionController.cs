using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.DeleteTransaction;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.UpdateTransaction;
using ProjectTemplate.Application.Features.Queries.TransactionQueries.GetByIdTransaction;

namespace ProjectTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ISender _sender;

        public TransactionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionCommandRequest request)
        {
            var response = await _sender.Send(request);
            return CreatedAtAction(nameof(Get),new {Id = response.Id},response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var response = await _sender.Send(new GetByIdTransactionQueryRequest(id));
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]UpdateTransactionCommandRequest request)
        {
            await _sender.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _sender.Send(new DeleteTransactionCommandRequest(id));
            return NoContent();
        }
    }
}
