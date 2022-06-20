namespace Database.Entities;

public class ApiUser
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string ApiKey { get; set; }
    public string OwnerName { get; set; }
    public byte[]? Password { get; set; }
    public byte[]? Salt { get; set; }
    public ICollection<UserClaim> UserClaims { get; set; }
}