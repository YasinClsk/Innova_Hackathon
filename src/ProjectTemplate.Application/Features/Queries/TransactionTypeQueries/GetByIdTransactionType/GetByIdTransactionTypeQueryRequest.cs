using MediatR;
using ProjectTemplate.Application.RequestParameters;

namespace ProjectTemplate.Application.Features.Queries.TransactionTypeQueries.GetByIdTransactionType
{
    public record GetByIdTransactionTypeQueryRequest(int Id, Pagination Pagination) 
        : IRequest<GetByIdTransactionTypeQueryResponse>;
}
