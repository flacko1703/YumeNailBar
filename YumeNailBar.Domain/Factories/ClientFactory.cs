using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Domain.SeedWork.ValueObjects;

namespace YumeNailBar.Domain.Factories;

public class ClientFactory : IClientFactory
{
    public Client Create(ClientName name, PhoneNumber phoneNumber) =>
        new(name, phoneNumber, new LinkedList<Procedure>(), string.Empty);
}