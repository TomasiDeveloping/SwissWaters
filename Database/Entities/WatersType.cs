namespace Database.Entities;

public class WatersType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Identifier { get; set; }
}