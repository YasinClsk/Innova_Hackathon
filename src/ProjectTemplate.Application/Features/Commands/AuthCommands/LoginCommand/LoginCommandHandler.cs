using MediatR;
using ProjectTemplate.Application.Abstractions.Handlers;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.AuthCommands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        public LoginCommandHandler(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByMailAsync(request.Email);

            if (user is null)
                throw new Exception("User not found");

            if(user.Password != request.Password)
                throw new Exception("The password is incorrect");

            var token = _tokenHandler.CreateToken(new TokenDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            });

            return new LoginCommandResponse(token);

        }
    }
}
