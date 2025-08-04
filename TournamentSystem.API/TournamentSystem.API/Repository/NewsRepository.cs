using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;
        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<News> CreateNewsAsync(News news)
        {
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task DeleteNewsAsync(int id)
        {
            var existing = await _context.News.FirstOrDefaultAsync(n => n.NewsId == id);

            if (existing != null)
            {
                _context.News.Remove(existing);
                 await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
           return await _context.News.FirstOrDefaultAsync(n => n.NewsId == id);
        }

        public async Task<News> UpdateNewsAsync(News news)
        {
                _context.Update(news);
                await _context.SaveChangesAsync();
                return news;    
        }
    }
}
