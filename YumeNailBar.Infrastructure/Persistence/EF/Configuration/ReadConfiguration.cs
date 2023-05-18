using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YumeNailBar.Infrastructure.Persistence.EF.Models;

namespace YumeNailBar.Infrastructure.Persistence.EF.Configuration;

internal sealed class ReadConfiguration 
    : IEntityTypeConfiguration<RegistrationReadModel>, 
    IEntityTypeConfiguration<CustomerReadModel>,
    IEntityTypeConfiguration<ProcedureReadModel>
{
    public void Configure(EntityTypeBuilder<RegistrationReadModel> builder)
    {
        builder.ToTable(YumeNailBarDbVariables.RegistrationTable);
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Customer).HasConversion(c => c.ToString(),
            c => CustomerReadModel.Create(c));
    }

    public void Configure(EntityTypeBuilder<CustomerReadModel> builder)
    {
        builder.ToTable(YumeNailBarDbVariables.ClientsTable);
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Procedures)
            .WithOne(x => x.Customer);
    }

    public void Configure(EntityTypeBuilder<ProcedureReadModel> builder)
    {
        builder.ToTable(YumeNailBarDbVariables.ProcedureTable);
        builder.HasKey(p => p.ProcedureKind);
    }
}