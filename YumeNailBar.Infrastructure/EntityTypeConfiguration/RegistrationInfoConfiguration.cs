using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YumeNailBar.Domain.AggregatesModel.RegistrationInfoAggregate;

namespace YumeNailBar.Infrastructure.EntityTypeConfiguration;

public class RegistrationInfoConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.HasKey(registrationInfo => registrationInfo.Id);
        builder.HasIndex(registrationInfo => registrationInfo.Id).IsUnique();
    }
}