using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Configuration;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Registration>, IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        var clientConverter = new ValueConverter<Customer, string>(c => c.ToString(),
            c => Customer.Create(c));
        
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasConversion(id => id.Value, id => new RegistrationId(id));
        builder.Property(typeof(Customer), "_client")
            .HasConversion(clientConverter)
            .HasColumnName("Client");
        builder.ToTable(YumeNailBarDbVariables.RegistrationTable);

    }

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property<Guid>("Id");
        builder.ToTable(YumeNailBarDbVariables.ClientsTable);
    }
}