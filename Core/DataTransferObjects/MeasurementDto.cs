namespace Core.DataTransferObjects;

public class MeasurementDto
{
    public Guid Id { get; set; }
    public Guid StationAbilityId { get; set; }
    public DateTime MeasurementTime { get; set; }
    public decimal Value { get; set; }
    public decimal? Max24H { get; set; }
    public decimal? Mean24H { get; set; }
    public decimal? Min24H { get; set; }
}