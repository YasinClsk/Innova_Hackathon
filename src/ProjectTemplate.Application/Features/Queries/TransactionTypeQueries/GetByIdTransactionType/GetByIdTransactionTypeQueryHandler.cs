using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Queries.TransactionTypeQueries.GetByIdTransactionType
{
    public class GetByIdTransactionTypeQueryHandler
        : IRequestHandler<GetByIdTransactionTypeQueryRequest, GetByIdTransactionTypeQueryResponse>
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IMapper _mapper;
        public GetByIdTransactionTypeQueryHandler(ITransactionTypeRepository transactionTypeRepository, IMapper mapper)
        {
            _transactionTypeRepository = transactionTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTransactionTypeQueryResponse> Handle(GetByIdTransactionTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var transactionType = await _transactionTypeRepository.GetByIdAsync(request.Id);
            var response = _mapper.Map<GetByIdTransactionTypeQueryResponse>(transactionType);

            return response;
        }
    }
}
