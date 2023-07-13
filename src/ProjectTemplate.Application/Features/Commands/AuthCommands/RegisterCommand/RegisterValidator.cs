using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.AuthCommands.RegisterCommand
{
    public class RegisterValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().MinimumLength(2);

            RuleFor(x => x.LastName)
                .NotNull().MinimumLength(2);

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(3);
        }
    }
}
