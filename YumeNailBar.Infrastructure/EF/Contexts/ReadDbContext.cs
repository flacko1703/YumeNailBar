using Microsoft.EntityFrameworkCore;
using YumeNailBar.Infrastructure.EF.Configuration;
using YumeNailBar.Infrastructure.EF.Models;

namespace YumeNailBar.Infrastructure.EF.Contexts;

internal class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<RegistrationReadModel> RegistrationReadModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("YumeNailBar");
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<RegistrationReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ClientReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ProcedureReadModel>(configuration);
    }
}