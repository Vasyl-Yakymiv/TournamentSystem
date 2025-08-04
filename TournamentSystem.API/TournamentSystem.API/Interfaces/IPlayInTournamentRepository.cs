using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface IPlayInTournamentRepository
    {
        Task<IEnumerable<Player>> GetPlayersByTournament(int tournamentId);
        Task<IEnumerable<PlayInTournament>> GetTeamsByTournament(int tournamentId);
        Task<PlayInTournament> CreateRegistrationInTournament(int tournamentId, int teamId);
        Task DeletePlayInTournament(int id);
        Task<PlayInTournament> UpdateTeamPlayInTournamet(int id);
        Task<PlayInTournament> GetPlayInTournamentById(int id);
    }
}
