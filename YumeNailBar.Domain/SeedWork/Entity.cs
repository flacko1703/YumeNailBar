namespace YumeNailBar.Domain.SeedWork;

public record Entity<TEntityId> : IEntity<TEntityId>
{
    public TEntityId Id { get; init; }
}

