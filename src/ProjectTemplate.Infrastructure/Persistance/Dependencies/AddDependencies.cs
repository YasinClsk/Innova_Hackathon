using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using ProjectTemplate.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Persistance.Dependencies
{
    public static class AddDependencies
    {
        public static void AddPersistanceDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:SqlServer"]);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserChargeRepository, UserChargeRepository>();
        }
    }
}
