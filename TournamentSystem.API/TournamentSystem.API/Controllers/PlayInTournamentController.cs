using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Dto.PlayInTournament;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;
using TournamentSystem.API.Repository;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayInTournamentController : Controller
    {
        private readonly IPlayInTournamentRepository _playInRepo;

        public PlayInTournamentController(IPlayInTournamentRepository playInRepo)
        {
            _playInRepo = playInRepo;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayInTournamentById(int id)
        {
            var play = await _playInRepo.GetPlayInTournamentById(id);
            if (play == null)
                return NotFound();
            return Ok(play);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistrationOnTournament([FromBody] CreatePlayInTournamentDto createPlayInTournamentDto)
        {
            if (createPlayInTournamentDto == null)
                return BadRequest();
            var created = await _playInRepo.CreateRegistrationInTournament(createPlayInTournamentDto.TournamentId,createPlayInTournamentDto.TeamId);

            return CreatedAtAction(nameof(GetPlayInTournamentById), new { id = created.PlayInId }, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeamPlayInTournamet(int id)
        {
            var play = _playInRepo.GetPlayInTournamentById(id);

            if (play == null)
                return NotFound();

            await  _playInRepo.UpdateTeamPlayInTournamet(id);
            return NoContent();
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetPlayersByTournament(int tournamentid)
        {
            var players = await _playInRepo.GetPlayersByTournament(tournamentid);
            return Ok(players);
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetTeamsByTournament(int tournamentId)
        {
             var teams = await _playInRepo.GetTeamsByTournament(tournamentId);
            return Ok(teams);
        }
    }
}
