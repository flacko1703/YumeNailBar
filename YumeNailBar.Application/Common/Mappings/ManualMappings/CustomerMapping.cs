using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;

namespace YumeNailBar.Application.Common.Mappings.ManualMappings;

public static class CustomerMapping
{
    public static CustomerDto MapToDto(this Customer customer)
    {
        return new CustomerDto(customer.Registrations.MapCollectionToDtos(),
            customer.GetName(),
            customer.GetPhoneNumber(),
            customer.GetEmail(),
            customer.GetComment());
    }

    public static Customer MapToModel(this CustomerDto dto)
    {
        return Customer.Create(dto.Registrations.MapCollectionToModels(),
            dto.Name,
            dto.PhoneNumber,
            dto.Email,
            dto.Comment);
    }

    public static IEnumerable<CustomerDto> MapCollectionToDtos(this IEnumerable<Customer> customers)
    {
        return customers.Select(customer 
            => new CustomerDto(customer.Registrations.MapCollectionToDtos(), 
                customer.GetName(), 
                customer.GetPhoneNumber(), 
                customer.GetEmail(), 
                customer.GetComment()))
            .ToList();
    }
    
    public static IEnumerable<Customer> MapCollectionToModels(this IEnumerable<CustomerDto> customers)
    {
        return customers.Select(customerDto 
            => Customer.Create(customerDto.Registrations.MapCollectionToModels(), 
                customerDto.Name, 
                customerDto.PhoneNumber, 
                customerDto.Email, 
                customerDto.Comment))
            .ToList();
    }
}