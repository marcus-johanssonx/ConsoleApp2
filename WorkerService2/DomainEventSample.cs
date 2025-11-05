public record DomainEventSample1(Guid Id, string Name, DateTimeOffset CreatedDate) : IDomainEvent;

public record DomainEventSample2(Guid Id, string Name, DateTimeOffset CreatedDate) : IDomainEvent;