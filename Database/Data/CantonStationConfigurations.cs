using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Data;

public class CantonStationConfigurations : IEntityTypeConfiguration<CantonStation>
{
    public void Configure(EntityTypeBuilder<CantonStation> builder)
    {
        builder.HasKey(cw => new {cw.CantonId, cw.StationId});

        builder.HasOne(cw => cw.Canton)
            .WithMany(cw => cw.CantonStations);

        builder.HasOne(cw => cw.Station)
            .WithMany(cw => cw.CantonStations);
    }
}