using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

namespace YumeNailBar.Blazor.Services;

public interface ICustomerService
{
    Task<CustomerDto> GetById(Guid id);
    Task AddAsync(CustomerDto customer);
}