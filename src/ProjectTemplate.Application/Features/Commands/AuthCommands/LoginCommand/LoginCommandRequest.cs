using MediatR;

namespace ProjectTemplate.Application.Features.Commands.AuthCommands.LoginCommand
{
    public record LoginCommandRequest(String Email,string Password) : IRequest<LoginCommandResponse>;
}
