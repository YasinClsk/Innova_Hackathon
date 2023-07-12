using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.DeleteTransactionType
{
    public class DeleteTransactionTypeCommandHandler
        : IRequestHandler<DeleteTransactionTypeCommandRequest>
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTransactionTypeCommandHandler(ITransactionTypeRepository transactionTypeRepository, IUnitOfWork unitOfWork)
        {
            _transactionTypeRepository = transactionTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTransactionTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await _transactionTypeRepository.Delete(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
