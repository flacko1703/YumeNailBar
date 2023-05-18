using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Application.Services;

public interface IRegistrationSearchService
{
    Task<Customer>? SearchByPhoneNumber(PhoneNumber phoneNumber);
}