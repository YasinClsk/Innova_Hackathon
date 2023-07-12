using ProjectTemplate.Application.DTO_s;
using System.Transactions;

namespace ProjectTemplate.Application.Features.Queries.TransactionTypeQueries.GetByIdTransactionType
{
    public record GetByIdTransactionTypeQueryResponse(TransactionTypeDTO TransactionType);
}
