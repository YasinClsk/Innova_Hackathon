using ProjectTemplate.Application.DTO_s;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.UpdateUser
{
    public record UpdateUserCommandResponse(int Id, String Email, String Password, String FirstName, String LastName);
}
