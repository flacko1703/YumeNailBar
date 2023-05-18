namespace YumeNailBar.Domain.Abstractions;

public record Entity<TEntityId> : IEntity<TEntityId>
{
    public TEntityId Id { get; init; }
}

