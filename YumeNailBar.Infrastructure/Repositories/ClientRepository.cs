using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.EF.Contexts;

namespace YumeNailBar.Infrastructure.Repositories;

internal class ClientRepository : IClientRepository
{
    private readonly ReadDbContext _readDbContext;
    private readonly WriteDbContext _writeDbContext;

    public ClientRepository(ReadDbContext readDbContext, WriteDbContext writeDbContext)
    {
        _readDbContext = readDbContext;
        _writeDbContext = writeDbContext;
    }

    public async Task<Client> GetAsync(PhoneNumber phoneNumber)
    {
        var result = await _readDbContext.Set<Client>()
            .FirstOrDefaultAsync(c => c.GetPhoneNumber() == phoneNumber);
        return result;
    }

    public async Task AddAsync(Client client)
    {
        await _writeDbContext.Set<Client>().AddAsync(client);
    }

    public async Task UpdateAsync(Client client)
    {
        return;
    }

    public Task DeleteAsync(Client client)
    {
        _writeDbContext.Set<Client>().Remove(client);
        return Task.CompletedTask;
    }
}