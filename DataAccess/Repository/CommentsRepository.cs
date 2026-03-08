using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class CommentsRepository(ParryTrainerDbContext context) : ICommentsRepository
{
    public async Task<List<Comments>> Get(Guid profileId)
    {
        var commentsEntity = await context.Comments.Where(x => x.ProfileId == profileId)
            .AsNoTracking()
            .ToListAsync();

        var comments = commentsEntity.Select(x => Comments.CreateComments(x.UserId, x.ProfileId, x.CommentId,
            x.Username, x.Text).comments).ToList();
        
        return comments;
    }

    public async Task<Guid> Post(Comments comments)
    {
        var commentEntity = new CommentsEntity
        {
            UserId = comments.UserId,
            ProfileId = comments.ProfileId,
            CommentId = comments.CommentId,
            Username = comments.Username,
            Text = comments.Text,
            DateCreated = comments.DateCreated
        };
        await context.Comments.AddAsync(commentEntity);
        await context.SaveChangesAsync();

        return comments.ProfileId;
    }

    public async Task<int> Delete(Guid profileId, int commentId)
    { 
        await context.Comments
            .Where(x => x.ProfileId == profileId && x.CommentId == commentId)
            .ExecuteDeleteAsync();
        
        return commentId;
    }
}