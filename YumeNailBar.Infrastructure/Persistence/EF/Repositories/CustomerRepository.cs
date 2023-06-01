using FluentResults;
using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using YumeNailBar.Domain.Repositories;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;
using Result = FluentResults.Result;

namespace YumeNailBar.Infrastructure.Persistence.EF.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly ICustomerDbContext _dbContext;
    

    public CustomerRepository(ICustomerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Customer>> GetAsync(CustomerId id)
    {
        var customer = await _dbContext.Customers.Include(x => x.Registrations)
            .ThenInclude(x => x.Procedures)
            .SingleOrDefaultAsync(customer => customer.Id == id);

        return customer ?? Result.Fail<Customer>($"Customer with id:{id} was not found");
    }

    public Result<IEnumerable<Customer>> GetAllCustomers()
    {
        var customers = _dbContext.Customers
            .Include(x => x.Registrations)
            .ThenInclude(x => x.Procedures).ToList();

        if (customers is null && !customers.Any())
        {
            return Result.Fail<IEnumerable<Customer>>("There is no customers in database");
        }

        return customers;
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