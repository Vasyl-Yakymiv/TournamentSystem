using TournamentSystem.API.Dto.Team;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<GetAllTeamDto>> GetAll();
        Task<Team> GetTeamById(int id);
        Task<Team> CreateTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
    }
}
