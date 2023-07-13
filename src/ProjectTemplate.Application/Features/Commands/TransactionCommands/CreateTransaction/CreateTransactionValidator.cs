using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction
{
    public class CreateTransactionValidator : AbstractValidator<CreateTransactionCommandRequest>
    {
        public CreateTransactionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Cost).GreaterThan(0);
        }
    }
}
