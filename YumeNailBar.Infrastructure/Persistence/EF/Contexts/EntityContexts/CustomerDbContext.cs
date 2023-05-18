using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Infrastructure.Persistence.EF.Configuration;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.EntityContexts;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(YumeNailBarDbVariables.SchemaName);
        var configuration = new CustomerConfiguration();
        modelBuilder.ApplyConfiguration(configuration);
    }
}