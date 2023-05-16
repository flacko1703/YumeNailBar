using Microsoft.EntityFrameworkCore;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;
using YumeNailBar.Infrastructure.EF.Configuration;

namespace YumeNailBar.Infrastructure.EF.Contexts;

public class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    public DbSet<Registration> Registrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("YumeNailBar");
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Registration>(configuration);
        modelBuilder.ApplyConfiguration<Client>(configuration);
    }
}