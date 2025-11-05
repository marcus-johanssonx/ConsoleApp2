public sealed class DomainEventsProcessorJob(
    InMemoryMessageQueue queue,
    IServiceScopeFactory serviceScopeFactory,
    ILogger<DomainEventsProcessorJob> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (IDomainEvent domainEvent in queue.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();

                var dispatcher = scope.ServiceProvider
                    .GetRequiredService<IDomainEventDispatcher>();

                await dispatcher.DispatchAsync(domainEvent, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Something went wrong! {DomainEventId}",
                    domainEvent);
            }
        }
    }
}