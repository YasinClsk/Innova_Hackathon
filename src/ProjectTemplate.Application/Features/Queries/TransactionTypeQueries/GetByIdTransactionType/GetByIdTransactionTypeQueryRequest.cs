using MediatR;

namespace ProjectTemplate.Application.Features.Queries.TransactionTypeQueries.GetByIdTransactionType
{
    public record GetByIdTransactionTypeQueryRequest(int Id) 
        : IRequest<GetByIdTransactionTypeQueryResponse>;
}
