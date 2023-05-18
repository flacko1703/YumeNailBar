using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

namespace YumeNailBar.Infrastructure.Persistence.Repositories;

internal class CustomerRepository : ICustomerRepository
{
    private readonly IApplicationDbContext _dbContext;

    public CustomerRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Customer> GetAsync(PhoneNumber phoneNumber)
    {
        var result = await _dbContext.Customers
            .FirstOrDefaultAsync(c => c.GetPhoneNumber() == phoneNumber);
        return result;
    }

    public async Task AddAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        return;
    }

    public Task DeleteAsync(Customer customer)
    {
        _dbContext.Customers.Remove(customer);
        return Task.CompletedTask;
    }
}