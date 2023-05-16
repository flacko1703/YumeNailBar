using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YumeNailBar.Domain.AggregatesModel.RegistrationAggregate;

namespace YumeNailBar.Infrastructure.EF.Configuration;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Registration>, IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        var clientConverter = new ValueConverter<Client, string>(c => c.ToString(),
            c => Client.CreateInstance(c));
        
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasConversion(id => id.Value, id => new RegistrationId(id));
        builder.Property(typeof(Client), "_client")
            .HasConversion(clientConverter)
            .HasColumnName(YumeNailBarDbTables.ClientsTable);
        builder.ToTable(YumeNailBarDbTables.RegistrationTable);

    }

    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property<Guid>("Id");
        builder.ToTable(YumeNailBarDbTables.ClientsTable);
    }
}