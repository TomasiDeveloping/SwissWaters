﻿// <auto-generated />
using System;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(SwissWatersContext))]
    [Migration("20220611122442_addWatersType")]
    partial class addWatersType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Database.Entities.Measurement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Max24H")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("Mean24H")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("MeasurementTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Min24H")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<Guid>("StationAbilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("StationAbilityId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Database.Entities.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Easting")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Northing")
                        .HasColumnType("int");

                    b.Property<string>("WatersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WatersTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WatersTypeId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Database.Entities.StationAbility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("StationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("StationAbilities");
                });

            modelBuilder.Entity("Database.Entities.WatersType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("WatersTypes");
                });

            modelBuilder.Entity("Database.Entities.Measurement", b =>
                {
                    b.HasOne("Database.Entities.StationAbility", "StationAbility")
                        .WithMany("Measurements")
                        .HasForeignKey("StationAbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StationAbility");
                });

            modelBuilder.Entity("Database.Entities.Station", b =>
                {
                    b.HasOne("Database.Entities.WatersType", "WatersType")
                        .WithMany()
                        .HasForeignKey("WatersTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("WatersType");
                });

            modelBuilder.Entity("Database.Entities.StationAbility", b =>
                {
                    b.HasOne("Database.Entities.Station", "Station")
                        .WithMany("StationAbilities")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Database.Entities.Station", b =>
                {
                    b.Navigation("StationAbilities");
                });

            modelBuilder.Entity("Database.Entities.StationAbility", b =>
                {
                    b.Navigation("Measurements");
                });
#pragma warning restore 612, 618
        }
    }
}