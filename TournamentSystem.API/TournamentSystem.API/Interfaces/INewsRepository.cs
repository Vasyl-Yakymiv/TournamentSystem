using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAll();
        Task<News> GetNewsByIdAsync(int id);
        Task<News> CreateNewsAsync(News news);
        Task<News> UpdateNewsAsync(News news);  
        Task DeleteNewsAsync(int id);

    }
}
