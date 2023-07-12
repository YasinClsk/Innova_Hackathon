using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Infrastructure.Infrastructure.Token;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using ProjectTemplate.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Infrastructure.Dependencies
{
    public static class AddDependencies
    {
        public static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddSingleton<TokenHandler>();
        }
    }
}
