using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Queries.UserQueries.GetByIdUser
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdProductQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null) 
                throw new Exception("Kullanıcı bulunamadı.");

            return new GetByIdProductQueryResponse(Email: user.Email,
                                                   FirstName: user.FirstName,
                                                   LastName: user.LastName);
        }
    }
}
