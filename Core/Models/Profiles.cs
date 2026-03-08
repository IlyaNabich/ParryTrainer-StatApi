namespace Core.Models;

public class Profiles
{
    private Profiles(Guid userId)
    {
        UserId = userId;
        ProfileId = Guid.NewGuid();
    }
    public Guid UserId { get; } 
    
    public Guid ProfileId { get; }
    
    public string FirstName { get; } = "Unknown";
    
    public string LastName { get; } = "Unknown";
    
    public string Age { get; } = "Unknown";
    
    public string Links { get; } = "Unknown";
    
    public string Region { get; } = "Unknown";
    
    public string Country { get; } = "Unknown";
    
    public string Description {  get; } = "Unknown";

    public static Profiles CreateProfile(Guid userId)
    {
       return new Profiles(userId);
    }
    
}