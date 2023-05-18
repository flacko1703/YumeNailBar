using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts;

namespace YumeNailBar.Infrastructure.Persistence.Repositories;

internal sealed class RegistrationRepository : IRegistrationRepository
{
    private readonly DbSet<Registration> _registrations;
    private readonly WriteDbContext _writeDbContext;

    public RegistrationRepository(WriteDbContext writeDbContext)
    {
        _registrations = writeDbContext.Registrations;
        _writeDbContext = writeDbContext;
    }

    public async Task<Registration?> GetAsync(RegistrationId id)
    {
        return await _registrations
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Registration registration)
    {
        await _writeDbContext.Set<Registration>().AddAsync(registration);
        await _writeDbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Registration registration)
    {
        _writeDbContext.Set<Registration>().Remove(registration);
        return Task.CompletedTask;
    }
}