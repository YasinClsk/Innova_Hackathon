using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Behaviors;
using ProjectTemplate.Application.Features.Commands.AuthCommands.LoginCommand;
using ProjectTemplate.Application.Features.Commands.AuthCommands.RegisterCommand;
using ProjectTemplate.Application.Features.Commands.TransactionCommands.CreateTransaction;
using ProjectTemplate.Application.Features.Commands.UserCommands.CreateUser;
using ProjectTemplate.Application.Mapping;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Dependencies
{
    public static class AddDependencies
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            services.AddScoped<IValidator<CreateUserCommandRequest>, CreateUserValidator>();
            services.AddScoped<IValidator<LoginCommandRequest>, LoginValidator>();
            services.AddScoped<IValidator<RegisterCommandRequest>, RegisterValidator>();
            services.AddScoped<IValidator<CreateTransactionCommandRequest>, CreateTransactionValidator>();

            services.AddAutoMapper(typeof(UserMappingProfile));
        }
    }
}
