using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Domain.Repositories;

public interface IRegistrationRepository 
{
    Task<Registration?> GetAsync(RegistrationId id);
    Task AddAsync(Registration registration);
    Task DeleteAsync(Registration registration);
}