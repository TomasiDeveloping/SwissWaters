namespace Database.Entities;

public class Measurement
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public StationAbility StationAbility { get; set; }
    public Guid StationAbilityId { get; set; }
    public DateTime MeasurementTime { get; set; }
    public decimal Value { get; set; }
    public decimal? Max24H { get; set; }
    public decimal? Mean24H { get; set; }
    public decimal? Min24H { get; set; }
}