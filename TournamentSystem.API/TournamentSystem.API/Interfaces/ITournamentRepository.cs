using System.Collections;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAll();
        Task<Tournament> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(Tournament tournament);
        Task<Tournament> UpdateAsync(Tournament tournament);
        Task DeleteAsync(int id);
    }
}
