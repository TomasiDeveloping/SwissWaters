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
    [Migration("20220614055217_addCanton")]
    partial class addCanton
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Database.Entities.ApiUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("ApiUsers");
                });

            modelBuilder.Entity("Database.Entities.Canton", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Cantons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5716545e-d27e-4745-8dcb-ee023176f983"),
                            Code = "AG",
                            Name = "Aargau"
                        },
                        new
                        {
                            Id = new Guid("80a07fc2-69de-4abb-9092-e1920347c8e0"),
                            Code = "AR",
                            Name = "Appenzell Ausserrhoden"
                        },
                        new
                        {
                            Id = new Guid("1df1c365-55f4-49cb-8a7b-702cd6c5896f"),
                            Code = "AI",
                            Name = "Appenzell Innerrhoden"
                        },
                        new
                        {
                            Id = new Guid("894210d0-ae51-431b-9d39-8ae09c3447a7"),
                            Code = "BL",
                            Name = "Basel-Landschaft"
                        },
                        new
                        {
                            Id = new Guid("17f586d2-4461-444e-bc19-3da43d1d9567"),
                            Code = "BS",
                            Name = "Basel-Stadt"
                        },
                        new
                        {
                            Id = new Guid("aceabbd5-c662-4b62-be44-7d66d2f082b0"),
                            Code = "BE",
                            Name = "Bern"
                        },
                        new
                        {
                            Id = new Guid("dceaf89e-80a1-4984-938c-2f4193c90008"),
                            Code = "FR",
                            Name = "Freiburg"
                        },
                        new
                        {
                            Id = new Guid("760d081f-cf05-4a67-8f7d-ab095f373a7e"),
                            Code = "GE",
                            Name = "Genf"
                        },
                        new
                        {
                            Id = new Guid("37e55fb8-a163-414b-a919-c5aabb13eef9"),
                            Code = "GL",
                            Name = "Glarus"
                        },
                        new
                        {
                            Id = new Guid("95fd99ce-acea-4680-bd0a-3ebc113357ac"),
                            Code = "GR",
                            Name = "Graubünden"
                        },
                        new
                        {
                            Id = new Guid("47b82674-9612-41f5-9b77-007167002e04"),
                            Code = "JU",
                            Name = "Jura"
                        },
                        new
                        {
                            Id = new Guid("cdeb7950-ffcf-485f-8ea1-e44f18909bc8"),
                            Code = "LU",
                            Name = "Luzern"
                        },
                        new
                        {
                            Id = new Guid("cd5cc8c7-7846-4fb9-b4a4-1fa18e0428d4"),
                            Code = "NE",
                            Name = "Neuenburg"
                        },
                        new
                        {
                            Id = new Guid("182380c0-f138-42c8-bb0a-00b6219c178b"),
                            Code = "NW",
                            Name = "Nidwalden"
                        },
                        new
                        {
                            Id = new Guid("711bde57-0040-49ea-90cf-140db48ec31b"),
                            Code = "OW",
                            Name = "Obwalden"
                        },
                        new
                        {
                            Id = new Guid("76107c5a-364a-4ee5-b7ce-24a980ade31a"),
                            Code = "SH",
                            Name = "Schaffhausen"
                        },
                        new
                        {
                            Id = new Guid("b9a4df45-6fcc-448b-b6ff-b7d1eadc9fca"),
                            Code = "SZ",
                            Name = "Schwyz"
                        },
                        new
                        {
                            Id = new Guid("76291f40-b773-4324-9351-96a7c947ef80"),
                            Code = "SO",
                            Name = "Solothurn"
                        },
                        new
                        {
                            Id = new Guid("c3cb4420-81fe-4d19-9e20-9114abf3dd83"),
                            Code = "SG",
                            Name = "St. Gallen"
                        },
                        new
                        {
                            Id = new Guid("24ae391c-7381-4c24-a6c4-d1d3bed8ced8"),
                            Code = "TI",
                            Name = "Tessin"
                        },
                        new
                        {
                            Id = new Guid("671fcec2-d9f0-4c81-a8ec-e646cbcd865b"),
                            Code = "TG",
                            Name = "Thurgau"
                        },
                        new
                        {
                            Id = new Guid("5031046d-7c2c-4643-afa0-96b046613dcf"),
                            Code = "UR",
                            Name = "Uri"
                        },
                        new
                        {
                            Id = new Guid("f711588e-d1b6-4eee-aabe-2822adfc023a"),
                            Code = "VD",
                            Name = "Waadt"
                        },
                        new
                        {
                            Id = new Guid("6abaca87-a74f-4447-bf70-90065e62c112"),
                            Code = "VS",
                            Name = "Wallis"
                        },
                        new
                        {
                            Id = new Guid("2bd5c275-5ca0-428a-9f33-9102110022ac"),
                            Code = "ZG",
                            Name = "Zug"
                        },
                        new
                        {
                            Id = new Guid("e629f4e2-f0ab-457f-9433-2d4856b2babc"),
                            Code = "ZH",
                            Name = "Zürich"
                        });
                });

            modelBuilder.Entity("Database.Entities.CantonStation", b =>
                {
                    b.Property<Guid>("CantonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CantonId", "StationId");

                    b.HasIndex("StationId");

                    b.ToTable("CantonStations");
                });

            modelBuilder.Entity("Database.Entities.Measurement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Max24H")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal?>("Mean24H")
                        .HasPrecision(18, 3)
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("MeasurementTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Min24H")
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

            modelBuilder.Entity("Database.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApiUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Database.Entities.WatersType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("WatersTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8e0baaa-27b4-4391-8b43-ea0ef0a472f7"),
                            Identifier = "LAKE",
                            Name = "See"
                        },
                        new
                        {
                            Id = new Guid("af331903-b86f-4836-8a74-40755fd7daaa"),
                            Identifier = "RIVER",
                            Name = "Fluss"
                        },
                        new
                        {
                            Id = new Guid("08108061-28dc-474f-8b85-b0b3ed787c22"),
                            Identifier = "STREAM",
                            Name = "Bach"
                        });
                });

            modelBuilder.Entity("Database.Entities.CantonStation", b =>
                {
                    b.HasOne("Database.Entities.Canton", "Canton")
                        .WithMany("CantonStations")
                        .HasForeignKey("CantonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.Station", "Station")
                        .WithMany("CantonStations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canton");

                    b.Navigation("Station");
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

            modelBuilder.Entity("Database.Entities.UserClaim", b =>
                {
                    b.HasOne("Database.Entities.ApiUser", "ApiUser")
                        .WithMany("UserClaims")
                        .HasForeignKey("ApiUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ApiUser");
                });

            modelBuilder.Entity("Database.Entities.ApiUser", b =>
                {
                    b.Navigation("UserClaims");
                });

            modelBuilder.Entity("Database.Entities.Canton", b =>
                {
                    b.Navigation("CantonStations");
                });

            modelBuilder.Entity("Database.Entities.Station", b =>
                {
                    b.Navigation("CantonStations");

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
