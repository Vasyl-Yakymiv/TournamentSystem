using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Dto.Transfer;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : Controller
    {
        private readonly ITransferRepository _transferRepo;
        public TransferController(ITransferRepository transfer_Repo)
        {
            _transferRepo = transfer_Repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTranfers()
        {
            var transfers = await _transferRepo.GetAll();
            return Ok(transfers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransferById(int id)
        {
            var transfer = await _transferRepo.GetTransferById(id);

            if (transfer == null) return NotFound();

            return Ok(transfer);
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetTransfersByPlayer(int playerId)
        {
            var transfers = await _transferRepo.GetTransferByPlayer(playerId);

            if (transfers == null) return NotFound();

            return Ok(transfers);
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetTransfersByTeam(int teamId)
        {
            var transfers = await _transferRepo.GetTransferByTeam(teamId);

            if (transfers == null) return NotFound();

            return Ok(transfers);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            var existing = await _transferRepo.GetTransferById(id);
            if (existing == null) return NotFound();

            _transferRepo.DeleteTransfer(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransfer([FromBody] CreateTransferDto createTransferDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (createTransferDto == null) return BadRequest();

            var transfer = new Transfer
            {
                PlayerId = createTransferDto.PlayerId,
                FromTeamId = createTransferDto.FromTeamId,
                ToTeamId = createTransferDto.ToTeamId,  
                TransferFee = createTransferDto.TransferFee

            };
            await _transferRepo.CreateTransfer(transfer);
            return CreatedAtAction(nameof(GetTransferById),new { id = transfer.TransferId}, transfer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransfer(int id, [FromBody] UpdateTransferDto updateTransferDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _transferRepo.GetTransferById(id);
            if (existing == null) return NotFound();


            existing.PlayerId = updateTransferDto.PlayerId;
            existing.FromTeamId = updateTransferDto.FromTeamId;
            existing.ToTeamId = updateTransferDto.ToTeamId;
            existing.TransferFee = updateTransferDto.TransferFee;

            await _transferRepo.UpdateTransfer(existing);
            return NoContent();
        }


    }
}
