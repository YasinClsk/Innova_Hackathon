using MediatR;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser
{
    public record CreateUserCommandRequest(string Email,
                                           string FirstName,
                                           string LastName,
                                           string Password) : IRequest<CreateUserCommandResponse>;
}
