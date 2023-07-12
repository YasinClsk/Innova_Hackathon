using AutoMapper;
using ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser;
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
        }
    }
}
