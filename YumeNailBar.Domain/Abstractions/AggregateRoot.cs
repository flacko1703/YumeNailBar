namespace YumeNailBar.Domain.Abstractions;

public abstract record AggregateRoot<T> : IDomainEvent
{
    private readonly List<IDomainEvent> _domainEvents = new();

    T Id { get; init; }

    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

    public void AddEvent(IDomainEvent @event)
    {
        if (!_domainEvents.Any())
        {
            _domainEvents.Add(@event);
        }
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }
}