namespace Database.Entities;

public class Station
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string WatersName { get; set; }
    public WatersType WatersType { get; set; }
    public Guid WatersTypeId { get; set; }
    public int Easting { get; set; }
    public int Northing { get; set; }
    public ICollection<StationAbility> SensorAbilities { get; set; }
}