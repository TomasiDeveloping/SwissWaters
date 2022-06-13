namespace Core.DataTransferObjects;

public class StationAbilityDto
{
    public Guid Id { get; set; }
    public Guid StationId { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }

    public ICollection<MeasurementDto> Measurements { get; set; }
}