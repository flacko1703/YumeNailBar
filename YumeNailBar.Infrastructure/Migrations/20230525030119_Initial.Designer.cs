﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YumeNailBar.Infrastructure.Persistence.EF.Contexts.ApplicationContext;

#nullable disable

namespace YumeNailBar.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20230525030119_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Comment");

                    b.Property<string>("_customerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("_email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("_phoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Procedure", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureKind")
                        .HasColumnType("int");

                    b.Property<Guid?>("RegistrationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Procedure");
                });

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Registration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("_appointmentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("AppointmentDate");

                    b.Property<bool>("_isCanceled")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Procedure", b =>
                {
                    b.HasOne("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Registration", null)
                        .WithMany("_procedures")
                        .HasForeignKey("RegistrationId");
                });

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Registration", b =>
                {
                    b.HasOne("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Customer", null)
                        .WithOne("_registration")
                        .HasForeignKey("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Registration", "CustomerId");
                });

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Customer", b =>
                {
                    b.Navigation("_registration");
                });

            modelBuilder.Entity("YumeNailBar.Domain.AggregateModels.CustomerAggregate.Entities.Registration", b =>
                {
                    b.Navigation("_procedures");
                });
#pragma warning restore 612, 618
        }
    }
}
