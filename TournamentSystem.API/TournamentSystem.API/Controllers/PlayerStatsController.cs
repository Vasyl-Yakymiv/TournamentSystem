using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Dto.PlayerStats;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerStatsController : Controller
    {
        private readonly IPlayerStatsRepository _playerStatsRepo;
        public PlayerStatsController(IPlayerStatsRepository playerStatsRepo)
        {
            _playerStatsRepo = playerStatsRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlayerAStats()
        {
            var playerStats = await _playerStatsRepo.GetAll();
            return Ok(playerStats);   
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopPlayerStats()
        {
            var playerStats = _playerStatsRepo.GetTopPlayerStats();
            return Ok(playerStats);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerStatsById(int id)
        {
            var player = _playerStatsRepo.GetPlayerStatsById(id);

            if (player == null) return BadRequest();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerStats(CreatePlayerStatsDto playerStatsDto)
        {
            if (playerStatsDto == null) return BadRequest();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var playerStats = new PlayerStats
            {
                PlayerId = playerStatsDto.PlayerId,
                Kills = playerStatsDto.Kills,
                Deaths = playerStatsDto.Deaths,
                Assists = playerStatsDto.Assists,
                Headshots = playerStatsDto.Headshots,
                HeadshotPercentage = playerStatsDto.HeadshotPercentage,
                AverageDamagePerRound = playerStatsDto.AverageDamagePerRound,
                Rating = playerStatsDto.Rating
            };
            var created = await _playerStatsRepo.CreatePlayerStats(playerStats);

            return CreatedAtAction(nameof(GetPlayerStatsById), new { id = created.StatsId }, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayerStats(int id,[FromBody] UpdatePlayerStatsDto playerStatsDto)
        {
            var updated =  await _playerStatsRepo.GetPlayerStatsById(id);

            if (updated == null) return BadRequest();

            updated.Headshots = playerStatsDto.Headshots;
            updated.Kills = playerStatsDto.Kills;
            updated.Assists = playerStatsDto.Assists;
            updated.Deaths = playerStatsDto.Deaths;
            updated.HeadshotPercentage = playerStatsDto.HeadshotPercentage;
            updated.AverageDamagePerRound = playerStatsDto.AverageDamagePerRound;
            updated.Rating = playerStatsDto.Rating;

            await _playerStatsRepo.UpdatePlayerStatsById(updated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayerStats(int id)
        {
            var existing = await _playerStatsRepo.GetPlayerStatsById(id);

            if (existing == null) return BadRequest();

            var deleted = _playerStatsRepo.DeletePlayerStatsById(id);

            return NoContent();
        }

    }
}
