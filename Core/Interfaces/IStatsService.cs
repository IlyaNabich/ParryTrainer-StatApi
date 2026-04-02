using Core.Models;

namespace Core.Interfaces;

public interface IStatsService
{
    public Task<Stats> GetUserStats(Guid userId);

    public Task<Guid> CreateStats(Stats stats);
    
    public Task<Guid> UpdateUserStats(Guid userId, Stats stats);
    
    public Task<Guid> ClearUserStats(Guid userId);
}