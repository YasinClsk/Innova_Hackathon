using Cronos;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using ProjectTemplate.Infrastructure.Persistance.Repositories;
using Sgbj.Cron;

namespace ProjectTemplate.Api.BackgroundServices
{
    public class DailyChargesService : BackgroundService
    {
        private readonly ILogger<DailyChargesService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public DailyChargesService(ILogger<DailyChargesService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //using var timer = new CronTimer("0 1 * * *", TimeZoneInfo.Local);
            using var timer = new CronTimer(CronExpression.Parse("*/30 * * * * *", CronFormat.IncludeSeconds));


            while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                await GetCharges();
            }
        }

        private async Task GetCharges()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var userChargeRepository = scope.ServiceProvider.GetRequiredService<IUserChargeRepository>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var users = await userRepository.GetAllAsync();
                foreach (var user in users)
                {
                    var dailyCost = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now, DateTime.Now.AddDays(-1));

                    await userChargeRepository.CreateAsync(new UserCharge
                    {
                        ChargeInterval = ChargeInterval.Daily,
                        Cost = dailyCost,
                        StartDate = DateTime.Now.AddDays(-1),
                        EndDate = DateTime.Now,
                        UserId = user.Id,
                    });
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }
    }
}
