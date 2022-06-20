namespace Core.DataTransferObjects;

public class ApiUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string ApiKey { get; set; }
    public string OwnerName { get; set; }
}