namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType
{
    public record CreateTransactionTypeCommandResponse(int Id, int UserId, String Title, String Description);
}
