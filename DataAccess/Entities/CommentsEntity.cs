namespace DataAccess.Entities;

public class CommentsEntity
{
    public Guid UserId { get; set; }
    
    public Guid ProfileId { get; set; }
    
    public int CommentId { get; set; }
    
    public string Username { get; set; }
    
    public string Text { get; set; }
    
    public DateTime DateCreated { get; set; } 
    
    public ProfilesEntity ProfilesEntity { get; set; }
}