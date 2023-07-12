using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Queries.TransactionQueries.GetByIdTransaction
{
    public class GetByIdTransactionQueryHandler : IRequestHandler<GetByIdTransactionQueryRequest, GetByIdTransactionQueryResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetByIdTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTransactionQueryResponse> Handle(GetByIdTransactionQueryRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);

            var response = _mapper.Map<GetByIdTransactionQueryResponse>(transaction);
            return response;
        }
    }

    public record GetByIdTransactionQueryRequest(int Id) : IRequest<GetByIdTransactionQueryResponse>;

    public record GetByIdTransactionQueryResponse
        (decimal Cost, String Name, String Description, DateTime TransactionDate, int TransactionTypeId);

}
