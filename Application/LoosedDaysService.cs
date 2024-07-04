using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application
{
    public class LoosedDaysService : BackgroundService
    {
        private readonly ILogger<LoosedDaysService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LoosedDaysService(ILogger<LoosedDaysService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("LoosedDaysService включен.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("LoosedDaysService запущен.");

                try
                {
                    await UpdateLoosedDays();

                    _logger.LogInformation("LoosedDaysService завершил цикл.");

                    await Task.Delay(TimeSpan.FromHours(12), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "ошибка в LoosedDaysService.");
                }
            }

            _logger.LogInformation("LoosedDaysService остановлен.");
        }

        private async Task UpdateLoosedDays()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var rentRepository = scope.ServiceProvider.GetRequiredService<IRentRepository>();
                await mediator.Send(new UpdateLoosedDaysCommand());
            }
        }
    }
}