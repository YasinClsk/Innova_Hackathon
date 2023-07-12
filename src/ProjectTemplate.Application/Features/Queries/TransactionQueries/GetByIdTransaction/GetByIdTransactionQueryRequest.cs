using MediatR;

namespace ProjectTemplate.Application.Features.Queries.TransactionQueries.GetByIdTransaction
{
    public record GetByIdTransactionQueryRequest(int Id) : IRequest<GetByIdTransactionQueryResponse>;

}
