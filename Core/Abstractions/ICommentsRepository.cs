using Core.Models;

namespace Core.Abstractions;

public interface ICommentsRepository
{
    public Task<Comments> GetCommentsAsync(Guid profileId);
    
    public Task<Comments> PostCommentsAsync(Guid userId,Guid commentatorId, string comment);
    
    public Task<Comments> DeleteCommentsAsync(Guid commentId);
}