namespace Core.Validations;

public static class CommentsValidation
{
    // ReSharper disable once InconsistentNaming
    private const int MAX_COMMENT_LENGTH = 128;
    
    public static string CommentValidate(string comment)
    {
        string error = string.Empty;
        if (comment.Length > MAX_COMMENT_LENGTH)
        {
            error = "Comment has max lenght - 128 characters";
        }
        return error;
    }
}