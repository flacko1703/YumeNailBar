using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Domain.Repositories;

public interface ICustomerRepository 
{
    Task<Customer?> GetAsync(CustomerId id);
    Task<IEnumerable<Customer>?> GetAllCustomers();
    Task AddAsync(Customer customer);
    Task DeleteAsync(Customer registration);
}