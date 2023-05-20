namespace YumeNailBar.Domain.SeedWork;

public abstract record AggregateRoot<T> : Entity<T>, IDomainEvent
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public T Id { get; init; }

    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

    public void AddEvent(IDomainEvent @event)
    {
        if (!_domainEvents.Any())
        {
            _domainEvents.Add(@event);
        }
    }

    public IEnumerable<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents;
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }
}