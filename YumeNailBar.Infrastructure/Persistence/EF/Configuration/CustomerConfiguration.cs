using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(DbNames.CustomerTable);
        
        //Id Configuration
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .IsRequired()
            .HasConversion(c => c.Value,
                value => new(value));

        //Registration Configuration
        builder.HasOne(typeof(Registration), "_registration")
            .WithOne()
            .HasForeignKey(typeof(Registration));
        
        //CustomerName Configuration
        var customerNameConversion = new ValueConverter<CustomerName, string>(name => name.Value,
            value => new CustomerName(value));
        builder.Property(typeof(CustomerName), "_customerName")
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(customerNameConversion)
            .HasColumnName("Name");

        //PhoneNumber Configuration
        var phoneNumberConversion = new ValueConverter<PhoneNumber, string>(phoneNumber => phoneNumber.Value,
            value => new PhoneNumber(value));
        builder.Property(typeof(PhoneNumber), "_phoneNumber")
            .IsRequired()
            .HasMaxLength(12)
            .HasConversion(phoneNumberConversion)
            .HasColumnName(nameof(PhoneNumber));

        //Email Configuration
        var emailConversion = new ValueConverter<Email, string>(email => email.Value,
            value => new Email(value));
        builder.Property(typeof(Email), "_email")
            .HasMaxLength(100)
            .HasConversion(emailConversion)
            .HasColumnName(nameof(Email));

        //Comment Configuration
        builder.Property(typeof(string), "_comment")
            .HasMaxLength(500)
            .HasColumnName("Comment");
    }
}