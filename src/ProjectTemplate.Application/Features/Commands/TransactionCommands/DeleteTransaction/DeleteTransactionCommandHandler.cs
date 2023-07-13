using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommandRequest>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            await _transactionRepository.Delete(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
