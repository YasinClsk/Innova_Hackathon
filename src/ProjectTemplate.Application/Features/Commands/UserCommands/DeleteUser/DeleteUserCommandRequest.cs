using MediatR;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.DeleteUser
{
    public record DeleteUserCommandRequest(int id)
        :IRequest<DeleteUserCommandResponse>;
}
