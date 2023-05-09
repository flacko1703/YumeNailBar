using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Domain.Repositories;

public interface IRegistrationRepository
{
    Task<Registration> GetAsync(RegistrationId id);
    Task AddAsync(Registration registration);
    Task UpdateAsync(Registration registration);
    Task DeleteAsync(Registration registration);
}