namespace ParryTrainerApi.Contracts.UserProfile;

public record ProfilesRequest(Guid userId, string firstName, string lastName, string age, string links, string region, string country, string description);