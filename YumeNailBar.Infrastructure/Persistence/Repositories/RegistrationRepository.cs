using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

namespace YumeNailBar.Infrastructure.Persistence.Repositories;

internal sealed class RegistrationRepository : IRegistrationRepository
{
    private readonly IApplicationDbContext _dbContext;

    public RegistrationRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Registration?> GetAsync(RegistrationId id)
    {
        return await _dbContext.Registrations
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Registration registration)
    {
        await _dbContext.Registrations.AddAsync(registration);
    }

    public Task DeleteAsync(Registration registration)
    {
        _dbContext.Registrations.Remove(registration);
        return Task.CompletedTask;
    }
}