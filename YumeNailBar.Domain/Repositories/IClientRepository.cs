using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Domain.Repositories;

public interface IClientRepository 
{
    Task<Client> GetAsync(PhoneNumber phoneNumber);
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(Client client);
}