using MediatR;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.UpdateTransactionType
{
    public record UpdateTransactionTypeCommandRequest(int Id,String Title, String Description)
        :IRequest<UpdateTransactionTypeCommandResponse>;
}
