using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.AuthCommands.LoginCommand
{
    public class LoginValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }
}
