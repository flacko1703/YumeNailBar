using Microsoft.EntityFrameworkCore;
using YumeNailBar.Infrastructure.Persistence.EF.Configuration;
using YumeNailBar.Infrastructure.Persistence.EF.Models;

namespace YumeNailBar.Infrastructure.Persistence.EF.Contexts.EntityContexts;

internal class ProcedureDbContext : DbContext
{
    public ProcedureDbContext(DbContextOptions<ProcedureDbContext> options) : base(options)
    {
    }
    
    public DbSet<ProcedureModel> Procedures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(YumeNailBarDbVariables.SchemaName);
        var configuration = new ProcedureConfiguration();
        modelBuilder.ApplyConfiguration(configuration);
    }
}