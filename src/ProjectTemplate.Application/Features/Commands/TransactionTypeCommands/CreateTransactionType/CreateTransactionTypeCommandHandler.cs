using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType
{
    public class CreateTransactionTypeCommandHandler
        : IRequestHandler<CreateTransactionTypeCommandRequest, CreateTransactionTypeCommandResponse>
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateTransactionTypeCommandHandler(ITransactionTypeRepository transactionTypeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _transactionTypeRepository = transactionTypeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTransactionTypeCommandResponse> Handle(CreateTransactionTypeCommandRequest request, CancellationToken cancellationToken)
        {

            var transactionType = _mapper.Map<TransactionType>(request);

            await _transactionTypeRepository.CreateAsync(transactionType);
            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<CreateTransactionTypeCommandResponse>(transactionType);
            return response;
        }
    }
}
