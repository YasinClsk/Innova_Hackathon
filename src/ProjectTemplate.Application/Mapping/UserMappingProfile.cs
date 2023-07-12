using AutoMapper;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType;
using ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser;
using ProjectTemplate.Application.Features.Commands.UserCommands.DeleteUser;
using ProjectTemplate.Application.Features.Commands.UserCommands.UpdateUser;
using ProjectTemplate.Application.Features.Queries.UserQueries.GetByIdUser;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommandRequest, User>();
            CreateMap<User, CreateUserCommandResponse>();

            CreateMap<User, UserDTO>();

            CreateMap<UpdateUserCommandRequest, User>();
            CreateMap<User, UpdateUserCommandResponse>();
        }
    }
}
