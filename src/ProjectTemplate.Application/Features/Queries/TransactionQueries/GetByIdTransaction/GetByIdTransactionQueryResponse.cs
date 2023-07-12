namespace ProjectTemplate.Application.Features.Queries.TransactionQueries.GetByIdTransaction
{
    public record GetByIdTransactionQueryResponse
        (decimal Cost, String Name, String Description, DateTime TransactionDate, int TransactionTypeId);

}
