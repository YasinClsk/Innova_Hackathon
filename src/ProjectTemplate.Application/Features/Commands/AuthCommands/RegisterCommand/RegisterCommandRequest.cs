using MediatR;

namespace ProjectTemplate.Application.Features.Commands.AuthCommands.RegisterCommand
{
    public record RegisterCommandRequest(String Email, String Password, String FirstName, String LastName)
        :IRequest<RegisterCommandResponse>;
}
