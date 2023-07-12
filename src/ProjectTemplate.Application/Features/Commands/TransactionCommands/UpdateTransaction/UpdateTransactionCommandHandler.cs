using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommandRequest>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);
            _transactionRepository.Update(transaction);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
