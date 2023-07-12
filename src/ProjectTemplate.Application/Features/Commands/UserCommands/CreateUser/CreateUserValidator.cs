using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
    {
        const int FirstNameMinimumLength = 2;
        const int FirstNameMaximumLength = 20;
        const int LastNameMinimumLength = 2;
        const int LastNameMaximumLength = 20;

        public CreateUserValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .MinimumLength(FirstNameMinimumLength)
                .MaximumLength(FirstNameMaximumLength);

            
            RuleFor(x => x.LastName).NotEmpty()
                .MinimumLength(LastNameMinimumLength)
                .MaximumLength(LastNameMaximumLength);

            RuleFor(x => x.Email).NotEmpty()
                .EmailAddress();
        }
    }
}
