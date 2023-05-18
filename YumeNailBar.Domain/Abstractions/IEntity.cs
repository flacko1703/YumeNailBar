namespace YumeNailBar.Domain.Abstractions;

public interface IEntity<T> 
{
    T Id { get; init; }
}