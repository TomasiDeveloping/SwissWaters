namespace Database.Entities;

public class StationAbility
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Station Station { get; set; }
    public Guid StationId { get; set; }

    public string Name { get; set; }
    public string Unit { get; set; }

    public ICollection<Measurement> Measurements { get; set; }
}