using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TournamentController(ApplicationDbContext context)
        {
           _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTournaments()
        {
            var touraments = await _context.Tournaments.ToListAsync();

            return Ok(touraments);
        }
    }
}
