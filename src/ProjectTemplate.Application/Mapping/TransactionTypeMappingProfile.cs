using AutoMapper;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType;
using ProjectTemplate.Application.Features.Queries.TransactionTypeQueries.GetByIdTransactionType;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Mapping
{
    public class TransactionTypeMappingProfile : Profile
    {
        public TransactionTypeMappingProfile() 
        {
            CreateMap<CreateTransactionTypeCommandRequest, TransactionType>();
            CreateMap<TransactionType, CreateTransactionTypeCommandResponse>();

            CreateMap<TransactionType, GetByIdTransactionTypeQueryResponse>();

            CreateMap<TransactionType, TransactionTypeDTO>();

        }
    }
}
