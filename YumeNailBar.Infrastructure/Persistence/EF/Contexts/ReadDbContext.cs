using Microsoft.EntityFrameworkCore;
using YumeNailBar.Infrastructure.Persistence.EF.Configuration;
using YumeNailBar.Infrastructure.Persistence.EF.Models;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts;

internal class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public ReadDbContext()
    {
        
    }

    public DbSet<RegistrationReadModel> RegistrationReadModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("YumeNailBar");
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<RegistrationReadModel>(configuration);
        modelBuilder.ApplyConfiguration<CustomerReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ProcedureReadModel>(configuration);
    }
}