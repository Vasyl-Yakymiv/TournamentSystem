using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface IPlayerStatsRepository
    {
        Task<IEnumerable<PlayerStats>> GetAll();
        Task<IEnumerable<PlayerStats>> GetTopPlayerStats();
        Task<PlayerStats> GetPlayerStatsById(int id);
        Task<PlayerStats> UpdatePlayerStatsById(PlayerStats playerStats);
        Task<PlayerStats> CreatePlayerStats(PlayerStats playerStats);
        Task DeletePlayerStatsById(int id); 

    }
}
