using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.SignalR;
using TournamentSystem.API.Dto.Match;
using TournamentSystem.API.Hubs;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _matchRepo;
        private readonly IHubContext<MatchHub> _hubContext;

        public MatchController(IMatchRepository matchRepo, IHubContext<MatchHub> hubContext)
        {
            _matchRepo = matchRepo;
            _hubContext = hubContext;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMatches()
        {
            var mathes = await _matchRepo.GetAll();
            return Ok(mathes);    
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveMatches()
        {
            var activeMatches = await _matchRepo.GetAllActiveMatches();
            return Ok(activeMatches);
        }
        [HttpGet("teams")]
        public async Task<IActionResult> GetAllMatchesByTeam(int teamId)
        {
            var teamMatches = await _matchRepo.GetMatchesByTeam(teamId);
            return Ok(teamMatches);
        }

        [HttpGet("tournament")]
        public async Task<IActionResult> GetAllMatchesByTournament(int tournamentId)
        {
            var tournamentMatches = await _matchRepo.GetMatchesByTournament(tournamentId);
            return Ok(tournamentMatches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchById(int id)
        {
            var match = await _matchRepo.GetMatchById(id);
            return Ok(match);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] CreateMatchDto createMatchDto)
        {
            if (createMatchDto == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var match = new Match
            {
                TeamAId = createMatchDto.TeamAId,
                TeamBId = createMatchDto.TeamBId,
                TournamentId = createMatchDto.TournamentId,
                MatchDate = createMatchDto.MatchDate,
                ScoreA = 0,
                ScoreB = 0
            };

            var created = await _matchRepo.CreateMatch(match);

            return CreatedAtAction(nameof(GetMatchById), new { id  = created.MatchId}, created);
        }

        [HttpPut("all")]
        public async Task<IActionResult> UpdateMatch(int id , UpdateMatchDto updateMatchDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _matchRepo.GetMatchById(id);

            if (existing == null) return BadRequest();

            existing.TeamAId = updateMatchDto.TeamAId;
            existing.TeamBId = updateMatchDto.TeamBId;
            existing.ScoreA = updateMatchDto.ScoreA; 
            existing.ScoreB = updateMatchDto.ScoreB;
            existing.MatchDate = updateMatchDto.MatchDate;  
            existing.WinnerTeamId = updateMatchDto.WinnerTeamId;

            await _matchRepo.UpdateMatch(existing);
            return NoContent();
        }

        [HttpPut("score")]
        public async Task<IActionResult> UpdateScoreMatch(int id, UpdateScoreMatchDto updateScoreMatchDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing =  await _matchRepo.GetMatchById(id);

            if (existing == null) return NotFound();  

            existing.ScoreA = updateScoreMatchDto.ScoreA;
            existing.ScoreB= updateScoreMatchDto.ScoreB;

            await _matchRepo.UpdateMatch(existing);

            await _hubContext.Clients.All.SendAsync("ScoreUpdated", new
            {
                MatchId = existing.MatchId,
                ScoreA = existing.ScoreA,
                ScoreB = existing.ScoreB
            });

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var existing =  await _matchRepo.GetMatchById(id);
            if (existing == null) return BadRequest();

            await _matchRepo.DeleteMatch(existing.MatchId);
            return NoContent();
        }
    }
}
