using YumeNailBar.Application.DTO;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

namespace YumeNailBar.Application.Common.Mappings.Manual;

public static class CustomerMap
{
    public static Customer ToDomainModel(this CustomerDto customerDto)
    {
        var customer = Customer.Create(customerDto.Registration.ToDomainModel(), customerDto.Name,
            customerDto.PhoneNumber, customerDto.Email, customerDto.Comment);
        return customer;
    }

    public static CustomerDto ToDto(this Customer customer)
    {
        var dto = new CustomerDto(customer.GetRegistration().ToDto(), customer.GetName(),
            customer.GetPhoneNumber(), customer.GetEmail(), customer.GetComment());
        return dto;
    }
}