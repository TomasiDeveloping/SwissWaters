namespace Database.Entities;

public class UserClaim
{
    public Guid Id { get; set; }
    public ApiUser ApiUser { get; set; }
    public Guid ApiUserId { get; set; }
    public string Name { get; set; }
}