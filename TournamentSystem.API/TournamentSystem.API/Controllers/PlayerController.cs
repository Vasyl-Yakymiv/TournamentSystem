using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Dto.Player;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepo;
        public PlayerController(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerRepo.GetAll();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerRepo.GetPlayerById(id);

            if (player == null) 
                return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            if (player == null)
                return BadRequest();

            var createPlayer = await _playerRepo.CreatePlayerAsync(player);

            return CreatedAtAction(nameof(GetPlayerById), new { id = createPlayer.PlayerId }, createPlayer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerDto playerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _playerRepo.GetPlayerById(id);

            if (existing == null)
                return NotFound();

            existing.TeamId = playerDto.TeamId;
            existing.NickName = playerDto.NickName;
            existing.Name = playerDto.Name;
            existing.Age = playerDto.Age;
            existing.Photo = playerDto.Photo;   

            await _playerRepo.UpdatePlayerAsync(existing);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var existing = await _playerRepo.GetPlayerById(id);

            if(existing == null)    
                return NotFound();

            var deletedPlayer = _playerRepo.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}
