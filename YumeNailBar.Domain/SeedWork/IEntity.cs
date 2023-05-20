namespace YumeNailBar.Domain.SeedWork;

public interface IEntity<TId> 
{
    TId Id { get; init; }
}