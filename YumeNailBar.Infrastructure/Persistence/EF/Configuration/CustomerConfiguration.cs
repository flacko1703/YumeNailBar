using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.RegistrationAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.Id)
            .HasConversion(customerId 
                => customerId.Value, value 
                => new CustomerId(value));
        builder.Property(customer => customer.PhoneNumber).HasConversion(x => x.Value, value => new PhoneNumber(value)).HasMaxLength(20);
        builder.Property(customer => customer.CustomerName).HasConversion(x => x.Value, value => new CustomerName(value)).HasMaxLength(100);
        builder.Property(customer => customer.Email).HasConversion(x => x.Value, value => new Email(value)).HasMaxLength(255);
        
        builder.HasIndex(customer => customer.PhoneNumber).IsUnique();

    }
}