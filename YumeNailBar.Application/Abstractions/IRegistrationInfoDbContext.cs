using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Application.Abstractions;

public interface IRegistrationInfoDbContext
{
    DbSet<Domain.AggregatesModel.RegistrationInfoAggregate.Registration> RegistrationInfo { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}