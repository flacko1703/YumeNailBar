using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public class CustomerFactory : ICustomerFactory
{
    public Customer Create(CustomerName name, PhoneNumber phoneNumber, Email? email = default) =>
        new(name, phoneNumber, email);
}