using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public interface ICustomerFactory
{
    Customer Create(CustomerName name, PhoneNumber phoneNumber, Email? email);
}