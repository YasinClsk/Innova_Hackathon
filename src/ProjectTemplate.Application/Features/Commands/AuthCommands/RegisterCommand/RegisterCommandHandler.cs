using MediatR;
using ProjectTemplate.Application.Abstractions.Handlers;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.DTO_s;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.AuthCommands.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCommandHandler(IUserRepository userRepository, ITokenHandler tokenHandler, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var userDb = await _userRepository.GetByMailAsync(request.Email);
            if (userDb is not null)
                throw new Exception("User already exsist");

            User user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
            };

            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var token = _tokenHandler.CreateToken(new TokenDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
            });

            return new RegisterCommandResponse(token);
        }
    }
}
