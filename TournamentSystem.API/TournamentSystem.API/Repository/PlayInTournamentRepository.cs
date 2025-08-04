using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TournamentSystem.API.Data;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class PlayInTournamentRepository : IPlayInTournamentRepository
    {

        private readonly ApplicationDbContext _context;
        public PlayInTournamentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PlayInTournament> CreateRegistrationInTournament(int tournamentId, int teamId)
        {
            var tournament = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == tournamentId);
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == teamId);

            var exists = await _context.PlayInTournaments
                               .AnyAsync(p => p.TournamentId == tournamentId && p.TeamId == teamId);

            if (exists)
            {
                return null;
            }

            PlayInTournament playInTour = new PlayInTournament()
            {
                TournamentId = tournamentId,
                TeamId = teamId
            };
            _context.PlayInTournaments.Add(playInTour);
            await _context.SaveChangesAsync();

            return playInTour;
        }

        public async Task DeletePlayInTournament(int id)
        {
            var deleted = await _context.PlayInTournaments.FirstOrDefaultAsync(x => x.PlayInId == id);

            if (deleted != null)
            {
                _context.Remove(deleted);
                await _context.SaveChangesAsync();  
            }
       }

        public async Task<IEnumerable<Player>> GetPlayersByTournament(int tournamentId)
        {
            var tournament = await _context.Tournaments.AnyAsync(t => t.Id == tournamentId);

            if (tournament == null)
            return Enumerable.Empty<Player>();

            var players = await _context.PlayInTournaments
                .Where(p => p.TournamentId == tournamentId)
                .Include(p => p.Team)
                .ThenInclude(t => t.Players)
                .SelectMany(p => p.Team.Players)
                .ToListAsync();

            return players;

        }

        public async Task<PlayInTournament> GetPlayInTournamentById(int id)
        {
            return await _context.PlayInTournaments.FirstOrDefaultAsync(p => p.PlayInId == id);
        }

        public async Task<IEnumerable<PlayInTournament>> GetTeamsByTournament(int tournamentId)
        {
            var tournament = await _context.Tournaments.AnyAsync(t => t.Id  == tournamentId);

            if (tournament == null)
            {
                return Enumerable.Empty<PlayInTournament>();
            }

            var teamsInTournament = await _context.PlayInTournaments
                .Where(p => p.TournamentId == tournamentId)
                .Include(t => t.Team)
                .ToListAsync();

            return teamsInTournament;
        }

        public async Task<PlayInTournament> UpdateTeamPlayInTournamet(int id)
        {
            var playInTournament = await _context.PlayInTournaments.FirstOrDefaultAsync(p => p.PlayInId == id);

            _context.Update(playInTournament);
            await _context.SaveChangesAsync();
            return playInTournament;
        }
    }
}
