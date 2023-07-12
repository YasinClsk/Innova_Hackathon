using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction
{
    public class CreateTransactionCommandHandler
        : IRequestHandler<CreateTransactionCommandRequest, CreateTransactionCommandResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper, ITransactionTypeRepository transactionTypeRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _transactionTypeRepository = transactionTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTransactionCommandResponse> Handle(CreateTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            if (!(await _transactionTypeRepository.AnyAsync(request.TransactionTypeId)))
                throw new Exception("Transaction type is not valid");


            var transaction = _mapper.Map<Transaction>(request);

            await _transactionRepository.CreateAsync(transaction);
            await _unitOfWork.SaveChangesAsync();
            var response = _mapper.Map<CreateTransactionCommandResponse>(transaction);

            return response;
        }
    }
}
