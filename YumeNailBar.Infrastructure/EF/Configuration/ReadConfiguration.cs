using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YumeNailBar.Infrastructure.EF.Models;

namespace YumeNailBar.Infrastructure.EF.Configuration;

internal sealed class ReadConfiguration 
    : IEntityTypeConfiguration<RegistrationReadModel>, 
    IEntityTypeConfiguration<ClientReadModel>,
    IEntityTypeConfiguration<ProcedureReadModel>
{
    public void Configure(EntityTypeBuilder<RegistrationReadModel> builder)
    {
        builder.ToTable(YumeNailBarDbTables.RegistrationTable);
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Client).HasConversion(c => c.ToString(),
            c => ClientReadModel.Create(c));
    }

    public void Configure(EntityTypeBuilder<ClientReadModel> builder)
    {
        builder.ToTable(YumeNailBarDbTables.ClientsTable);
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Procedures)
            .WithOne(x => x.Client);
    }

    public void Configure(EntityTypeBuilder<ProcedureReadModel> builder)
    {
        builder.ToTable(YumeNailBarDbTables.ProcedureTable);
        builder.HasKey(p => p.ProcedureKind);
    }
}