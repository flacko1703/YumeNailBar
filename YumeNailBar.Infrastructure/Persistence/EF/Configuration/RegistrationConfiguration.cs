﻿using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace YumeNailBar.Infrastructure.Persistence.EF.Configuration;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        //AppointmentDate Configuration
        builder.HasKey(r => r.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(x => x.Value, 
                value => new RegistrationId(value));

        
        //AppointmentDate Configuration
        var appointmentDateConversion = new ValueConverter<AppointmentDate, DateTime>(date => date.Value,
            value => new AppointmentDate(value));
        builder.Property(typeof(AppointmentDate), "_appointmentDate")
            .HasConversion(appointmentDateConversion)
            .HasColumnName(nameof(AppointmentDate));
        
        //IsCanceled Configuration
        builder.Property(typeof(bool), "_isCanceled")
            .HasColumnName("Status");
        
        //Procedures Configuration
        builder.HasMany(typeof(Procedure), "_procedures")
            .WithOne();
    }
}