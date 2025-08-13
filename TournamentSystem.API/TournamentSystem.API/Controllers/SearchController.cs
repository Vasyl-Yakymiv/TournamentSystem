using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Services;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("Query cannot be empty");

            var results = await _searchService.Search(q);
            return Ok(results);
        }   
    }
}
