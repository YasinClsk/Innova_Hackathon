using MediatR;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction
{
    public record CreateTransactionCommandRequest
        (decimal Cost, String Name, String Description, DateTime TransactionDate, int TransactionTypeId)
        :IRequest<CreateTransactionCommandResponse>;
}
