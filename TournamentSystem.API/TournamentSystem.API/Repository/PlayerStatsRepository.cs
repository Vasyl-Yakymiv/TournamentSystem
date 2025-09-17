using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class PlayerStatsRepository : IPlayerStatsRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerStatsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PlayerStats> CreatePlayerStats(PlayerStats playerStats)
        {
           await  _context.PlayerStats.AddAsync(playerStats);
           await _context.SaveChangesAsync();
           return playerStats;
        }

        public async Task DeletePlayerStatsById(int id)
        {
            var playerStats = _context.PlayerStats.FirstOrDefault(p => p.StatsId == id);

            if (playerStats != null)
            {
                _context.PlayerStats.Remove(playerStats);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<PlayerStats>> GetAll()
        {
            return await _context.PlayerStats
                .Include(p => p.Player)
                .ToListAsync();
        }

        public async Task<PlayerStats> GetPlayerStatsById(int id)
        {
            return await _context.PlayerStats
                .Include(p => p.Player)
                .FirstOrDefaultAsync(p => p.StatsId == id);
        }

        public async Task<IEnumerable<PlayerStats>> GetTopPlayerStats()
        {
            return await _context.PlayerStats
                .OrderByDescending(p => p.KD)
                .Take(100)
                .ToListAsync();
        }

        public async Task<PlayerStats> UpdatePlayerStatsById(PlayerStats playerStats)
        {
          _context.PlayerStats.Update(playerStats);
          await _context.SaveChangesAsync();
            return playerStats;
        }
    }
}
