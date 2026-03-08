using Core.Abstractions;
using Core.Interfaces;
using Core.Models;

namespace Application.Services;

public class CommentsService (ICommentsRepository repository) : ICommentsService
{
    public async Task<List<Comments>> Get(Guid profileId) => await repository.Get(profileId);

    public async Task<Guid> Post(Comments comments) => await repository.Post(comments);

    public async Task<int> Delete(Guid profileId,int commentId) => await repository.Delete(profileId,commentId);
}