public interface IEventBus
{
    Task PublishAsync<T>(
        T domainEvent,
        CancellationToken cancellationToken = default)
        where T : class, IDomainEvent;
}

public sealed class InMemoryEventBus(InMemoryMessageQueue queue,ILogger<InMemoryEventBus> logger) : IEventBus
{
    public async Task PublishAsync<T>(
        T domainEvent,
        CancellationToken cancellationToken = default)
        where T : class, IDomainEvent
    {
        logger.LogInformation("Event {name} added to queue: {time}", domainEvent.Name,  DateTimeOffset.Now);
        await queue.Writer.WriteAsync(domainEvent, cancellationToken);
    }
}

