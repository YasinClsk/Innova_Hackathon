using MediatR;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.DeleteTransactionType
{
    public record DeleteTransactionTypeCommandRequest(int Id) : IRequest;
}
