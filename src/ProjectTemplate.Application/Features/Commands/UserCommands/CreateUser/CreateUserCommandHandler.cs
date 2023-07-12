using AutoMapper;
using FluentValidation;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (_userRepository.Get(x => x.Email == request.Email).Any())
                throw new Exception("Aynı e-mail adresine sahip bir kullanici bulunuyor.");

            User user = _mapper.Map<User>(request);

            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            CreateUserCommandResponse response = _mapper.Map<CreateUserCommandResponse>(user);
            return response;
        }
    }
}
