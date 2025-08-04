using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TournamentSystem.API.Data;
using TournamentSystem.API.Dto.Player;
using TournamentSystem.API.Dto.Team;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<Team> CreateTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();  
            return team;
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team != null)
            { 
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GetAllTeamDto>> GetAll()
        {
            var teams = await _context.Teams.Include(t => t.Players).ToListAsync();
            var result = teams.Select(t => new GetAllTeamDto
            {
                TeamId = t.TeamId,
                TeamName = t.TeamName,
                Players = t.Players.Select(p => new GetAllPlayerDto
                {
                    PlayerId = p.PlayerId,
                    NickName = p.NickName,
                    Age = p.Age,
                    Image = p.Photo
                }).ToList()
            }).ToList();

            return result;
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
           _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }
    }
}
