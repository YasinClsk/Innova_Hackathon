using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using Sgbj.Cron;

namespace ProjectTemplate.Api.BackgroundServices
{
    public class WeeklyChargesService : BackgroundService
    {
        private const int WEEK = 7;

        private readonly ILogger<WeeklyChargesService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public WeeklyChargesService(ILogger<WeeklyChargesService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new CronTimer("0 0 * * 1", TimeZoneInfo.Local);

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
                    var weeklyCost = await userRepository
                        .UserChargesBetweenDates(user.Id, DateOnly.FromDateTime(DateTime.Now.AddDays(-WEEK)), DateOnly.FromDateTime(DateTime.Now));

                    await userChargeRepository.CreateAsync(new UserCharge
                    {
                        ChargeInterval = ChargeInterval.Weekly,
                        Cost = weeklyCost,
                        StartDate = DateTime.Now.AddDays(-WEEK),
                        EndDate = DateTime.Now,
                        UserId = user.Id,
                    });

                    await unitOfWork.SaveChangesAsync();
                }
            }
        }
    }
}
