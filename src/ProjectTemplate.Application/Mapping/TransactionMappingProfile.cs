using AutoMapper;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.UpdateTransaction;
using ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.UpdateTransactionType;
using ProjectTemplate.Application.Features.Queries.TransactionQueries.GetByIdTransaction;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Mapping
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<CreateTransactionCommandRequest,Transaction>();
            CreateMap<Transaction,CreateTransactionCommandResponse>();

            CreateMap<Transaction, GetByIdTransactionQueryResponse>();

            CreateMap<Transaction, TransactionDTO>();

            CreateMap<UpdateTransactionCommandRequest, Transaction>();
        }
    }
}
