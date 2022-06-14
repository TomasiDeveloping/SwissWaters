namespace Core.DataTransferObjects;

public class StationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string WatersName { get; set; }
    public string WatersTypeName { get; set; }
    public int Easting { get; set; }
    public int Northing { get; set; }
    public List<string> CantonNames { get; set; }
    public ICollection<StationAbilityDto> StationAbilities { get; set; }
}