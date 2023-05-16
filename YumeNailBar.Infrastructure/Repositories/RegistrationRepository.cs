using Microsoft.EntityFrameworkCore;
using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.EF.Contexts;

namespace YumeNailBar.Infrastructure.Repositories;

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
    }

    public Task DeleteAsync(Registration registration)
    {
        _writeDbContext.Set<Registration>().Remove(registration);
        return Task.CompletedTask;
    }
}