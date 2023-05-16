using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public interface IClientFactory
{
    Client Create(ClientName name, PhoneNumber phoneNumber);
}