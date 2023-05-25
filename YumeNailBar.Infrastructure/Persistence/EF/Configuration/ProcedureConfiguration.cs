using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Configuration;

public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
{
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(x => x.Value, 
                value => new ProcedureId(value));
        builder.Property(x => x.ProcedureKind).IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (ProcedureKind)Enum.Parse(typeof(ProcedureKind), v));
        builder.Property(x => x.Price).IsRequired();
    }
}