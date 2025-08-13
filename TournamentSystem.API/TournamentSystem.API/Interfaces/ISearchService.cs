using TournamentSystem.API.Dto.Search;

namespace TournamentSystem.API.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResultDto>> Search(string query);
    }
}
