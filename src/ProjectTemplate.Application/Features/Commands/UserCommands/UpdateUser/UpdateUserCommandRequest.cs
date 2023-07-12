using MediatR;
using ProjectTemplate.Application.DTO_s;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.UpdateUser
{
    public record UpdateUserCommandRequest(int Id, String Email, String Password, String FirstName, String LastName)
        :IRequest<UpdateUserCommandResponse>;
}
