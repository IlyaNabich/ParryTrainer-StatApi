using Core.Models;

namespace Core.Interfaces;

public interface ICommentsService
{
    public Task<List<Comments>> Get(Guid profileId);
    
    public Task<Guid> Post(Comments comments);
    
    public Task<int> Delete(Guid profileId, int commentId);
}