using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetTeamById(int id);
        Task<Team> CreateTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
    }
}
