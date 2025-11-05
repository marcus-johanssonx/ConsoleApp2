public interface IDomainEvent
{
    Guid Id { get; }
    string Name { get; }
}

