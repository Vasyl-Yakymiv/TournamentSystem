using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Match>> GetAll();
        Task<IEnumerable<Match>> GetAllActiveMatches();
        Task<IEnumerable<Match>> GetMatchesByTournament(int tournamentId);
        Task<IEnumerable<Match>> GetMatchesByTeam(int teamId);
        Task<Match> GetMatchById(int id);
        Task<Match> CreateMatch(Match match);
        Task<Match> UpdateMatch(Match match);
        Task DeleteMatch(int id);
    }
}
