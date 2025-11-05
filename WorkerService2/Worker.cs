namespace WorkerService2
{
    public class Worker(ILogger<Worker> logger, IEventBus eventBus) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        private readonly IEventBus eventBus = eventBus;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var random = new Random();
            await Task.Delay(1000, stoppingToken);


            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker Publish to event bus at: {time}", DateTimeOffset.Now);

                if (random.Next(2) == 0)    
                {

                    await eventBus.PublishAsync(new DomainEventSample1(Guid.NewGuid(), "Sample Event1", DateTimeOffset.Now), stoppingToken);
                }
                else
                {
                    await eventBus.PublishAsync(new DomainEventSample2(Guid.NewGuid(), "Sample Event2", DateTimeOffset.Now), stoppingToken);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
