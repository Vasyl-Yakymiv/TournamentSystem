using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TournamentSystem.API.Data;
using TournamentSystem.API.Dto;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        ITournamentRepository _tournamentRepo;
        public TournamentController(ITournamentRepository tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTournaments()
        {
            var tournaments = await _tournamentRepo.GetAll();

            return Ok(tournaments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournamentById(int id)
        {
            var tournament = await _tournamentRepo.GetByIdAsync(id);

            return Ok(tournament);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTournament([FromBody] Tournament tournament)
        {
            if (tournament == null)
                return BadRequest();

            var createdTournament = await _tournamentRepo.CreateAsync(tournament);

            return CreatedAtAction(nameof(GetTournamentById), new { id = createdTournament.Id }, createdTournament);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, [FromBody] UpdateTournamentDto updateTournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await  _tournamentRepo.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Title = updateTournamentDto.Title;
            existing.Description = updateTournamentDto.Description;
            existing.PrizeMoney = updateTournamentDto.PrizeMoney;
            existing.Logo = updateTournamentDto.Logo;

            var updated = await _tournamentRepo.UpdateAsync(existing);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var existing = await _tournamentRepo.GetByIdAsync(id);
            if (existing == null)
               return NotFound();

            await _tournamentRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
