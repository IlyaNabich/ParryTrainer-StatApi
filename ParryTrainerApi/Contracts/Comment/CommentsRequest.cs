namespace ParryTrainerApi.Contracts.Comment;

public record CommentsRequest(Guid UserId,Guid ProfileId, int CommentId, string Text, string Username, DateTime DateCreated);