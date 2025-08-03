using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Dto.Team;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {

        private readonly ITeamRepository _teamRepo;
        public TeamController(ITeamRepository teamRepo)
        {
                _teamRepo = teamRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams =  await _teamRepo.GetAll();

            return Ok(teams);   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamRepo.GetTeamById(id);

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            if (team == null)
                return BadRequest();

            var created =  await _teamRepo.CreateTeamAsync(team);

            return CreatedAtAction(nameof(GetTeamById), new { id = created.TeamId }, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] UpdateTeamDto updateTeamDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing  =  await _teamRepo.GetTeamById(id);

            if (existing == null)
                return NotFound();

            existing.TeamName = updateTeamDto.TeamName;
            existing.TeamLogo = updateTeamDto.TeamLogo;
            existing.PlayerAgeAvg = updateTeamDto.PlayerAgeAvg;



            await _teamRepo.UpdateTeamAsync(existing);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var existing = _teamRepo.GetTeamById(id);

            if (existing == null)
                return NotFound();

            await _teamRepo.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}
