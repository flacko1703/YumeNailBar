using YumeNailBar.Application.Common.Mappings;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.DTO;

public record CustomerDto(Guid Id, RegistrationDto Registration, string Name, string PhoneNumber, string? Email, string? Comment) 
    : IMapWith<Customer>
{
    public Customer ToDomainModel()
    {
        return Customer.Create(Registration.ToDomainModel(), Name, PhoneNumber, Email, Comment);
    }
}

