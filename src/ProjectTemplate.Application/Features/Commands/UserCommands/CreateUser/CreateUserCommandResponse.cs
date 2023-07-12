namespace ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser
{
    public record CreateUserCommandResponse(int Id,
                                            string Email,
                                            string FirstName,
                                            string LastName);
}
