using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Infrastructure.Persistence.EF.Configuration;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.EntityContexts;

public class RegistrationDbContext : DbContext
{
    public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Registration> Registrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(YumeNailBarDbVariables.SchemaName);
        var configuration = new RegistrationConfiguration();
        modelBuilder.ApplyConfiguration(configuration);
    }
}