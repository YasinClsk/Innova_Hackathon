using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionTypeCommands.CreateTransactionType
{
    public class CreateTransactionTypeValidator : AbstractValidator<CreateTransactionTypeCommandRequest>
    {
        public CreateTransactionTypeValidator() 
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
