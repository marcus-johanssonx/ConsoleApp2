public class DomainEventSample1EventHandler(ILogger<DomainEventSample1> logger) : IDomainEventHandler<DomainEventSample1>
{
    public async Task Handle(DomainEventSample1 domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling {Name} at {Time}", domainEvent.Name, DateTimeOffset.Now);

        await Task.Delay(500, cancellationToken);
    }
}


public class DomainEventSample2EventHandler(ILogger<DomainEventSample2> logger) : IDomainEventHandler<DomainEventSample2>
{
    public async Task Handle(DomainEventSample2 domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling {Name} at {Time}", domainEvent.Name, DateTimeOffset.Now);

        await Task.Delay(1000, cancellationToken);
    }
}