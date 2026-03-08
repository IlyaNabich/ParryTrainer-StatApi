namespace ParryTrainerApi.Contracts.Comment;

public record CommentsResponse(string Text, string Username, DateTime DateCreated);