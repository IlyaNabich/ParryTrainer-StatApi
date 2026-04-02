using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class ProfilesRepository (ParryTrainerDbContext context): IProfilesRepository
{
    
    
    public async Task<Profiles> GetUserProfileAsync(Guid userId)
    {
        var userProfileEntity = await context.Profiles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        
        var userProfile = Profiles.CreateProfile(userProfileEntity.UserId,  userProfileEntity.ProfileId);
        
        return userProfile;
    }

    public async Task<Guid> CreateUserProfileAsync(Profiles profiles)
    {
        var userProfileEntity = new ProfilesEntity
        {
            UserId = profiles.UserId,
            FirstName = profiles.FirstName,
            LastName = profiles.LastName,
            Age = profiles.Age,
            Links = profiles.Links,
            Region = profiles.Region,
            Country = profiles.Country,
            Description = profiles.Description
        };
        
        await context.Profiles.AddAsync(userProfileEntity);
        await context.SaveChangesAsync();
        
        return profiles.UserId;
    }

    public async Task<Guid> UpdateUserProfileAsync(Guid userId, string firstName, string lastName, string age, string links, string region, string country, string description)
    {
        await context.Profiles
            .Where(x => x.UserId == userId)
            .ExecuteUpdateAsync(x => x
                .SetProperty(a => a.FirstName, firstName)
                .SetProperty(b => b.LastName, lastName)
                .SetProperty(d => d.Age, age)
                .SetProperty(e => e.Links, links)
                .SetProperty(f => f.Region, region)
                .SetProperty(g => g.Country, country)
                .SetProperty(h => h.Description, description));
        
        return userId;
    }
}