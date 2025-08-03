using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAll();
        Task<Player> GetPlayerById(int id);
        Task<Player> UpdatePlayerAsync(Player player);
        Task<Player> CreatePlayerAsync(Player player);
        Task DeletePlayerAsync(int id);

    }
}
