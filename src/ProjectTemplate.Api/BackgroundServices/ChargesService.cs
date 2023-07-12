using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Infrastructure.Persistance.Repositories;

namespace ProjectTemplate.Api.BackgroundServices
{
    public class ChargesService : BackgroundService
    {
        private readonly ILogger<ChargesService> _logger;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromMinutes(15));
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

                var users = await userRepository.GetAllAsync();
                foreach (var user in users)
                {
                    var daily = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-1), DateTime.Now);

                    var weekly = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-7), DateTime.Now);

                    var monthly = await userRepository
                        .UserChargesBetweenDates(user.Id, DateTime.Now.AddDays(-30), DateTime.Now);

                    await Console.Out.WriteLineAsync
                        ($"{user.FirstName} {user.LastName} Daily : {daily} Weekly : {weekly} Monthly : {monthly}");
                }
            }
        }

    }
}
