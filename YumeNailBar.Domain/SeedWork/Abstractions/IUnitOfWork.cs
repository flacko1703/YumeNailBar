namespace YumeNailBar.Domain.SeedWork.Abstractions;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}