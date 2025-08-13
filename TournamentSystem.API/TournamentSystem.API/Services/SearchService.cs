using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;
using TournamentSystem.API.Dto.Search;
using TournamentSystem.API.Interfaces;

namespace TournamentSystem.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext _context;

        public SearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SearchResultDto>> Search(string query)
        {
            var players = await _context.Players
                .Where(p => p.NickName.Contains(query) || p.Name.Contains(query))
                .Select(p => new SearchResultDto
                {
                    Type = "Player",
                    Id = p.PlayerId,
                    Name = p.NickName,
                    AdditionalInfo = p.Team.TeamName
                }).ToListAsync();

            var teams = await _context.Teams
                .Where(t => t.TeamName.Contains(query))
                .Select(t => new SearchResultDto
                {
                    Type = "Team",
                    Id = t.TeamId,
                    Name = t.TeamName
                }).ToListAsync();

            var news = await _context.News
                .Where(n => n.Title.Contains(query))
                .Select(n => new SearchResultDto
                {
                    Type = "News",
                    Id = n.NewsId,
                    Name = n.Title
                }).ToListAsync();

            var tournaments = await _context.Tournaments
                .Where(t => t.Title.Contains(query))
                .Select(t => new SearchResultDto
                {
                    Type = "Tournament",
                    Id = t.Id,
                    Name = t.Title
                }).ToListAsync();

            return players.Concat(teams).Concat(news).Concat(tournaments);
        }
    }
}
