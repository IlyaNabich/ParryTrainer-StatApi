using Core.Validations;

namespace Core.Models;

public class Comments
{
    public Guid UserId { get; }
    
    public Guid ProfileId { get; }
    
    public int CommentId { get; }
    
    public string Username { get; }
    
    public string Text { get; }
    
    public DateTime DateCreated { get; }

    private Comments(Guid userId, Guid profileId, int commentId, string username, string text)
    {
        UserId = userId;
        ProfileId = profileId;
        CommentId = commentId;
        Username = username;
        Text = text;
        DateCreated = DateTime.UtcNow;
    }

    public static (Comments comments, string error) CreateComments(Guid userId, Guid profileId, int commentId, string username, string text)
    {
        var error = CommentsValidation.CommentValidate(text);
        var comments = new Comments(userId, profileId, commentId, username, text);
        
        return (comments, error);
    }
    
}