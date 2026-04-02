using Core.Abstractions;
using Core.Interfaces;
using Core.Models;

namespace Application.Services;

public class StatsService (IStatsRepository statsRepository) : IStatsService
{

    public async Task<Stats> GetUserStats(Guid userId) => 
        await statsRepository.Get(userId);
    

    public async Task<Guid> CreateStats(Stats stats) =>
        await statsRepository.Create(stats);
    

    public async Task<Guid> UpdateUserStats(Guid userId, Stats stats) =>
        await statsRepository.Update(userId, stats);
    

    public async Task<Guid> ClearUserStats(Guid userId) => 
        await statsRepository.Clear(userId);
    
}