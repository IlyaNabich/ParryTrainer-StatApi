using Core.Abstractions;
using Core.Interfaces;
using Core.Models;

namespace Application.Services;

public class ProfilesService (IProfilesRepository profilesRepository) : IProfilesService
{
    
    public async Task<Profiles> GetUserProfileAsync(Guid userId) =>
        await profilesRepository.GetUserProfileAsync(userId);
    

    public async Task<Guid> CreateUserProfileAsync(Profiles profiles) =>
        await profilesRepository.CreateUserProfileAsync(profiles);
    

    public async Task<Guid> UpdateUserProfileAsync(Guid userId, string firstName, string lastName, string age, string links, string region, string country, string description) =>
         await profilesRepository.UpdateUserProfileAsync(userId, firstName, lastName, age, links, region, country, description);
    
}