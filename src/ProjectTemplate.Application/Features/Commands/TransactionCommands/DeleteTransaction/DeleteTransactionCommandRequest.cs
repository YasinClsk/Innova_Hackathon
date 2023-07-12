using MediatR;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.DeleteTransaction
{
    public record DeleteTransactionCommandRequest(int Id) : IRequest;
}
