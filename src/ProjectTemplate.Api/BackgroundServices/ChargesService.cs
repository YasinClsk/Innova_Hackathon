using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Enums;
using ProjectTemplate.Infrastructure.Persistance.Repositories;

namespace ProjectTemplate.Api.BackgroundServices
{
    public class ChargesService : BackgroundService
    {
        private const int DAY = 1;
        private const int WEEK = 7;
        private const int MONTH = 30;

        private readonly ILogger<ChargesService> _logger;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(15));
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ChargesService(ILogger<ChargesService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
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
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-DAY), DateTime.Now);

                    var weeklyCost = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-WEEK), DateTime.Now);

                    var monthlyCost = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-MONTH), DateTime.Now);


                    await userChargeRepository.CreateAsync(new UserCharge
                    {
                        ChargeInterval = ChargeInterval.Daily,
                        Cost = dailyCost,
                        StartDate = DateTime.Now.AddDays(-DAY),
                        EndDate = DateTime.Now,
                        UserId = user.Id,
                    });

                    await userChargeRepository.CreateAsync(new UserCharge
                    {
                        ChargeInterval = ChargeInterval.Weekly,
                        Cost = dailyCost,
                        StartDate = DateTime.Now.AddDays(-WEEK),
                        EndDate = DateTime.Now,
                        UserId = user.Id,
                    });

                    await userChargeRepository.CreateAsync(new UserCharge
                    {
                        ChargeInterval = ChargeInterval.Monthly,
                        Cost = dailyCost,
                        StartDate = DateTime.Now.AddDays(-MONTH),
                        EndDate = DateTime.Now,
                        UserId = user.Id,
                    });

                    await unitOfWork.SaveChangesAsync();

                    await Console.Out.WriteLineAsync
                        ($"{user.FirstName} {user.LastName} Daily : {dailyCost} Weekly : {weeklyCost} Monthly : {monthlyCost}");
                }
            }
        }
    }
}
