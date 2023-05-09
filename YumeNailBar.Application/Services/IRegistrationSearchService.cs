using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.Services;

public interface IRegistrationSearchService
{
    Task<bool> SearchByPhoneNumber(PhoneNumber phoneNumber);
}