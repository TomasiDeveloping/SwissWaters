using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Data;

public class CantonConfigurations : IEntityTypeConfiguration<Canton>
{
    public void Configure(EntityTypeBuilder<Canton> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Code).IsRequired().HasMaxLength(2);

        builder.HasData(
            new List<Canton>
            {
                new() {Id = Guid.NewGuid(), Name = "Aargau", Code = "AG"},
                new() {Id = Guid.NewGuid(), Name = "Appenzell Ausserrhoden", Code = "AR"},
                new() {Id = Guid.NewGuid(), Name = "Appenzell Innerrhoden", Code = "AI"},
                new() {Id = Guid.NewGuid(), Name = "Basel-Landschaft", Code = "BL"},
                new() {Id = Guid.NewGuid(), Name = "Basel-Stadt", Code = "BS"},
                new() {Id = Guid.NewGuid(), Name = "Bern", Code = "BE"},
                new() {Id = Guid.NewGuid(), Name = "Freiburg", Code = "FR"},
                new() {Id = Guid.NewGuid(), Name = "Genf", Code = "GE"},
                new() {Id = Guid.NewGuid(), Name = "Glarus", Code = "GL"},
                new() {Id = Guid.NewGuid(), Name = "Graubünden", Code = "GR"},
                new() {Id = Guid.NewGuid(), Name = "Jura", Code = "JU"},
                new() {Id = Guid.NewGuid(), Name = "Luzern", Code = "LU"},
                new() {Id = Guid.NewGuid(), Name = "Neuenburg", Code = "NE"},
                new() {Id = Guid.NewGuid(), Name = "Nidwalden", Code = "NW"},
                new() {Id = Guid.NewGuid(), Name = "Obwalden", Code = "OW"},
                new() {Id = Guid.NewGuid(), Name = "Schaffhausen", Code = "SH"},
                new() {Id = Guid.NewGuid(), Name = "Schwyz", Code = "SZ"},
                new() {Id = Guid.NewGuid(), Name = "Solothurn", Code = "SO"},
                new() {Id = Guid.NewGuid(), Name = "St. Gallen", Code = "SG"},
                new() {Id = Guid.NewGuid(), Name = "Tessin", Code = "TI"},
                new() {Id = Guid.NewGuid(), Name = "Thurgau", Code = "TG"},
                new() {Id = Guid.NewGuid(), Name = "Uri", Code = "UR"},
                new() {Id = Guid.NewGuid(), Name = "Waadt", Code = "VD"},
                new() {Id = Guid.NewGuid(), Name = "Wallis", Code = "VS"},
                new() {Id = Guid.NewGuid(), Name = "Zug", Code = "ZG"},
                new() {Id = Guid.NewGuid(), Name = "Zürich", Code = "ZH"}
            }
        );
    }
}