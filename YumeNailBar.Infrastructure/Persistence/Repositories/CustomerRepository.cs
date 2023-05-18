using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts;

namespace YumeNailBar.Infrastructure.Persistence.Repositories;

internal class CustomerRepository : ICustomerRepository
{
    private readonly ReadDbContext _readDbContext;
    private readonly WriteDbContext _writeDbContext;

    public CustomerRepository(ReadDbContext readDbContext, WriteDbContext writeDbContext)
    {
        _readDbContext = readDbContext;
        _writeDbContext = writeDbContext;
    }

    public async Task<Customer> GetAsync(PhoneNumber phoneNumber)
    {
        var result = await _readDbContext.Set<Customer>()
            .FirstOrDefaultAsync(c => c.GetPhoneNumber() == phoneNumber);
        return result;
    }

    public async Task AddAsync(Customer customer)
    {
        await _writeDbContext.Set<Customer>().AddAsync(customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        return;
    }

    public Task DeleteAsync(Customer customer)
    {
        _writeDbContext.Set<Customer>().Remove(customer);
        return Task.CompletedTask;
    }
}