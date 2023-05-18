using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

public interface IApplicationDbContext
{
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
}