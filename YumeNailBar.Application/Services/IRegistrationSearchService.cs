using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Application.Services;

public interface IRegistrationSearchService
{
    Task<Client>? SearchByPhoneNumber(PhoneNumber phoneNumber);
}