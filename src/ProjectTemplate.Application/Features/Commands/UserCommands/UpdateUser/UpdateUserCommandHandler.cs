using AutoMapper;
using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (!(await _userRepository.AnyAsync(request.Id)))
                throw new Exception("User Not Found");

            var user = _mapper.Map<User>(request);
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            var response = _mapper.Map<UpdateUserCommandResponse>(user);
            return response;
        }
    }
}
