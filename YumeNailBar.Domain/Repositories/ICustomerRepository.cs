using FluentResults;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Domain.Repositories;

public interface ICustomerRepository 
{
    Task<Result<Customer>> GetAsync(CustomerId id);
    Result<IEnumerable<Customer>> GetAllCustomers();
    Task AddAsync(Customer customer);
    Task DeleteAsync(Customer registration);
}