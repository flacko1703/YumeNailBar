using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

namespace YumeNailBar.Infrastructure.Persistence.EF.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly ICustomerDbContext _dbContext;

    public CustomerRepository(ICustomerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer?> GetAsync(CustomerId id)
    {
        return await _dbContext.Customers
            .SingleOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task<IEnumerable<Customer>?> GetAllCustomers()
    {
        return _dbContext.Customers;
    }

    public async Task AddAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
    }

    public Task DeleteAsync(Customer customer)
    {
        _dbContext.Customers.Remove(customer);
        return Task.CompletedTask;
    }
}