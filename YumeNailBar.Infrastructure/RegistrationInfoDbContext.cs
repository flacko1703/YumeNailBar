using Microsoft.EntityFrameworkCore;
using YumeNailBar.Application.Abstractions;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;
using YumeNailBar.Infrastructure.EntityTypeConfiguration;

namespace YumeNailBar.Infrastructure;

public class RegistrationInfoDbContext : DbContext
{
    public DbSet<Registration> RegistrationInfo { get; set; }

    public RegistrationInfoDbContext(DbContextOptions<RegistrationInfoDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RegistrationInfoConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}