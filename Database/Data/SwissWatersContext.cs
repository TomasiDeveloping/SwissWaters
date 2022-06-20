using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Data;

public class SwissWatersContext : DbContext
{
    public SwissWatersContext(DbContextOptions<SwissWatersContext> options) : base(options)
    {
    }

    public DbSet<Station> Stations { get; set; }

    public DbSet<WatersType> WatersTypes { get; set; }
    public DbSet<StationAbility> StationAbilities { get; set; }
    public DbSet<Measurement> Measurements { get; set; }

    public DbSet<ApiUser> ApiUsers { get; set; }

    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<Canton> Cantons { get; set; }
    public DbSet<CantonStation> CantonStations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Station>().HasKey(s => s.Id);
        modelBuilder.Entity<Station>().Property(s => s.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<Station>()
            .HasOne(s => s.WatersType)
            .WithMany()
            .HasForeignKey(s => s.WatersTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<WatersType>().HasKey(wt => wt.Id);
        modelBuilder.Entity<WatersType>().Property(wt => wt.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<WatersType>().Property(wt => wt.Identifier).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<WatersType>().HasData(new List<WatersType>()
        {
            new() {Id = Guid.NewGuid(), Name = "See", Identifier = "LAKE"},
            new() { Id = Guid.NewGuid(), Name = "Fluss", Identifier = "RIVER"},
            new() { Id = Guid.NewGuid(), Name = "Bach", Identifier = "STREAM"}
        });

        modelBuilder.Entity<StationAbility>().HasKey(sa => sa.Id);
        modelBuilder.Entity<StationAbility>().Property(sa => sa.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<StationAbility>().Property(sa => sa.Unit).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<StationAbility>()
            .HasOne(sa => sa.Station)
            .WithMany(sa => sa.StationAbilities)
            .HasForeignKey(s => s.StationId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Measurement>().HasKey(m => m.Id);
        modelBuilder.Entity<Measurement>().Property(m => m.Value).IsRequired().HasPrecision(18, 3);
        modelBuilder.Entity<Measurement>().Property(m => m.Max24H).IsRequired(false).HasPrecision(18, 3);
        modelBuilder.Entity<Measurement>().Property(m => m.Min24H).IsRequired(false).HasPrecision(18, 3);
        modelBuilder.Entity<Measurement>().Property(m => m.Mean24H).IsRequired(false).HasPrecision(18, 3);

        modelBuilder.Entity<ApiUser>().HasKey(au => au.Id);
        modelBuilder.Entity<ApiUser>().Property(au => au.Salt).IsRequired(false);
        modelBuilder.Entity<ApiUser>().Property(au => au.Password).IsRequired(false);
        modelBuilder.Entity<ApiUser>().Property(au => au.Email).IsRequired().HasMaxLength(155);
        modelBuilder.Entity<ApiUser>().Property(au => au.ApiKey).IsRequired();
        modelBuilder.Entity<ApiUser>().Property(au => au.OwnerName).IsRequired().HasMaxLength(150);

        modelBuilder.Entity<UserClaim>().HasKey(uc => uc.Id);
        modelBuilder.Entity<UserClaim>().Property(uc => uc.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserClaim>()
            .HasOne(uc => uc.ApiUser)
            .WithMany(uc => uc.UserClaims)
            .HasForeignKey(uc => uc.ApiUserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.ApplyConfiguration(new CantonConfigurations());

        modelBuilder.ApplyConfiguration(new CantonStationConfigurations());
    }
}