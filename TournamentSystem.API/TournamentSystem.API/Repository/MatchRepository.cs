using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using TournamentSystem.API.Data;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;
        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Match> CreateMatch(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task DeleteMatch(int id)
        {
            var deleted = await _context.Matches.FindAsync(id);

            if (deleted != null)
            {
                _context.Matches.Remove(deleted);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<IEnumerable<Match>> GetAll()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<IEnumerable<Match>> GetAllActiveMatches()
        {
            return await _context.Matches.Where(m => m.WinnerTeamId == null).ToListAsync();
        }

        public async Task<Match> GetMatchById(int id)
        {
            return await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == id);
        }

        public async Task<IEnumerable<Match>> GetMatchesByTeam(int teamId)
        {
            var teamExisting = await _context.Teams.AnyAsync(t => t.TeamId == teamId);
            if(!teamExisting) return Enumerable.Empty<Match>();
            return await _context.Matches
                .Include(m => m.TeamA)
                .Include(m => m.TeamB)
                .Where(m => m.TeamAId == teamId || m.TeamBId == teamId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Match>> GetMatchesByTournament(int tournamentId)
        {
            var tournamentExisting = await _context.Tournaments.AnyAsync(t => t.Id == tournamentId);
            if(!tournamentExisting) return Enumerable.Empty<Match>();
            return await _context.Matches.Where(m =>  m.TournamentId == tournamentId).ToListAsync();
        }

        public async Task<Match> UpdateMatch(Match match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
            return match;
        }
    }
}
