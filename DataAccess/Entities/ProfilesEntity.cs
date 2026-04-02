namespace DataAccess.Entities;

public class ProfilesEntity
{
    public Guid UserId { get; set; }
    
    public Guid ProfileId { get; set; }
    
    public string FirstName { get; set; } = "Unknown";
    
    public string LastName { get; set; } = "Unknown";
    
    public string Age { get; set; } = string.Empty;
    
    public string Links { get; set; } = "Unknown";
    
    public string Region { get; set; } = "Unknown";
    
    public string Country { get; set; } = "Unknown";
    
    public string Description {  get; set; } = "Unknown";
    
    public UsersEntity UsersEntity { get; set; }
    
    public List<CommentsEntity> CommentsEntity { get; set; } = null!;
}