namespace ParryTrainerApi.Contracts.UserProfile;

public record ProfilesResponse(Guid userId, string firstName, string lastName, string age, string links, string region, string country, string description);

    
