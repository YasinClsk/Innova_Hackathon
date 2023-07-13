using Cronos;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using Sgbj.Cron;

namespace ProjectTemplate.Api.BackgroundServices
{
    public class MonthlyChargesService : BackgroundService
    {
        private const int MONTH = 30;

        private readonly ILogger<MonthlyChargesService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public MonthlyChargesService(ILogger<MonthlyChargesService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //using var timer = new CronTimer("0 1 1 * *", TimeZoneInfo.Local);
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

                    var monthlyCost = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-MONTH), DateTime.Now);

                    await userChargeRepository.CreateAsync(new UserCharge
                    {
                        ChargeInterval = ChargeInterval.Monthly,
                        Cost = monthlyCost,
                        StartDate = DateTime.Now.AddDays(-MONTH),
                        EndDate = DateTime.Now,
                        UserId = user.Id,
                    });

                    await unitOfWork.SaveChangesAsync();
                }
            }
        }
    }
}
