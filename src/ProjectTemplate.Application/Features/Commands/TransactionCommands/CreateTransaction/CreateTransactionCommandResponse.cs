namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction
{
    public record CreateTransactionCommandResponse
        (decimal Cost, String Name, String Description, DateTime TransactionDate, int TransactionTypeId,int Id);
}
