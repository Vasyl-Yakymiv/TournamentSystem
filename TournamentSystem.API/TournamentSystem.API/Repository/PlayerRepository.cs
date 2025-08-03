using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using TournamentSystem.API.Data;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository( ApplicationDbContext context)
        {
              _context = context;
        }
        public async Task<Player> CreatePlayerAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if(player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();  
            }

        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _context.Players.Include(p =>p.Team).ToListAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Players
                .Include(p =>p.Team)
                .FirstOrDefaultAsync(p => p.PlayerId == id);
        }

        public async Task<Player> UpdatePlayerAsync(Player player)
        {
          _context.Players.Update(player);
          await _context.SaveChangesAsync();
          return player;

        }
    }
}
