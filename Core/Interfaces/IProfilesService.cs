using Core.Models;

namespace Core.Interfaces;

public interface IProfilesService
{
    public Task<Profiles> GetUserProfileAsync(Guid userId);
    
    public Task<Guid> CreateProfileAsync(Profiles profiles);
    
    public Task<Guid> UpdateUserProfileAsync(Guid userId, string firstName, string lastName, string age, string links, string region, string country, string description);
}