using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface IPlayInTournamentRepository
    {
        Task<IEnumerable<Player>> GetPlayersByTournament(int tournamentId);
        Task<IEnumerable<CreatePlayInTournamentDto>> GetTeamsByTournament(int tournamentId);
        Task<CreatePlayInTournamentDto> CreateRegistrationInTournament(int tournamentId, int teamId);
        Task DeletePlayInTournament(int id);
        Task<CreatePlayInTournamentDto> UpdateTeamPlayInTournamet(int id);
        Task<CreatePlayInTournamentDto> GetPlayInTournamentById(int id);
    }
}
