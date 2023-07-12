using MediatR;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.UpdateTransaction
{
    public record UpdateTransactionCommandRequest
        (decimal Cost, String Name, String Description, DateTime TransactionDate, int Id)
        :IRequest;
}
