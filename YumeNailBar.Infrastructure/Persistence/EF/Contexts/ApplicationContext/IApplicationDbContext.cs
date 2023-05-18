using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

public interface IApplicationDbContext
{
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Customer> Clients { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
}