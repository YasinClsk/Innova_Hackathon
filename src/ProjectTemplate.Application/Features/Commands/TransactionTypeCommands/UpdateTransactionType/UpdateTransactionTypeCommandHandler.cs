using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.UpdateTransactionType
{
    public class UpdateTransactionTypeCommandHandler
        : IRequestHandler<UpdateTransactionTypeCommandRequest, UpdateTransactionTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTransactionTypeCommandHandler(IMapper mapper, ITransactionTypeRepository transactionTypeRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _transactionTypeRepository = transactionTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateTransactionTypeCommandResponse> Handle(UpdateTransactionTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var dbTransactionType = await _transactionTypeRepository.GetByIdAsync(request.Id);
            var transactionType = _mapper.Map(request, dbTransactionType);
            
            _transactionTypeRepository.Update(transactionType!);
            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<UpdateTransactionTypeCommandResponse>(transactionType);
            return response;
        }
    }
}
