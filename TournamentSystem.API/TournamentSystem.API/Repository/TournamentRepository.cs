using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext _context;
        public TournamentRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            await _context.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task DeleteAsync(int id)
        {
           var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tournament>> GetAll()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Tournament> GetByIdAsync(int id)
        {
            return await _context.Tournaments
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tournament> UpdateAsync(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }
    }
}
