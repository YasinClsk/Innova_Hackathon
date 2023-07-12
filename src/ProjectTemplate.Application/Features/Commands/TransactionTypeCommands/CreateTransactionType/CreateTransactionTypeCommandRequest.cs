using MediatR;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType
{
    public record CreateTransactionTypeCommandRequest(int UserId, String Title, String Description)
        : IRequest<CreateTransactionTypeCommandResponse>;
}
