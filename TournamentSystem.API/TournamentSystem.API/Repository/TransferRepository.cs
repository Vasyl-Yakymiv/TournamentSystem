using Microsoft.EntityFrameworkCore;
using TournamentSystem.API.Data;
using TournamentSystem.API.Dto.Transfer;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;
        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Transfer> CreateTransfer(Transfer transfer)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == transfer.PlayerId);

            if (player != null)
            {
                player.TeamId = transfer.ToTeamId;
            }

            transfer.TransferDate = DateTime.UtcNow;
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
            return transfer;
        }

        public async Task DeleteTransfer(int id)
        {
           var transfer = await _context.Transfers.FindAsync(id);

            if (transfer != null)
            {
                _context.Transfers.Remove(transfer);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<TransferDto>> GetAll()
        {
            var transfers = await _context.Transfers
            .Include(t => t.Player)
            .Include(t => t.FromTeam)
            .Include(t => t.ToTeam)
            .Select(t => new TransferDto
            {
            TransferId = t.TransferId,
            PlayerId = t.PlayerId,
            PlayerName = t.Player.NickName,
            FromTeamId = t.FromTeamId.Value,
            FromTeamName = t.FromTeam.TeamName,
            ToTeamId = t.ToTeamId.Value,
            ToTeamName = t.ToTeam.TeamName,
            TransferDate = t.TransferDate,
            TransferFee = t.TransferFee
            })
            .ToListAsync();

            return transfers;
        }

        public async Task<Transfer> GetTransferById(int id)
        {
            return await _context.Transfers.FirstOrDefaultAsync(t => t.TransferId == id);
        }

        public async Task<IEnumerable<Transfer>> GetTransferByPlayer(int playerId)
        {
            var playerExists = await _context.Players.AnyAsync(p => p.PlayerId == playerId);
            if (!playerExists) return Enumerable.Empty<Transfer>();

            return await _context.Transfers
                .Include(p => p.Player)
                .Where(p => p.PlayerId == playerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TransferDto>> GetTransferByTeam(int teamId)
        {
            var teamExists = await _context.Teams.AnyAsync(t => t.TeamId == teamId);
            if (!teamExists) return Enumerable.Empty<TransferDto>();

            return await _context.Transfers
                .Include(t => t.Player)
                .Include(t => t.FromTeam)
                .Include(t => t.ToTeam)
                .Where(t => t.FromTeamId == teamId || t.ToTeamId == teamId)
                .Select(t => new TransferDto
                {
                    TransferId = t.TransferId,
                    PlayerId = t.Player.PlayerId,
                    PlayerName = t.Player.NickName,
                    FromTeamId = t.FromTeam.TeamId,
                    FromTeamName = t.FromTeam.TeamName,
                    ToTeamId = t.ToTeam.TeamId,
                    ToTeamName = t.ToTeam.TeamName,
                    TransferDate = t.TransferDate,
                    TransferFee = t.TransferFee
                })
                .ToListAsync();
        }

        public async Task<Transfer> UpdateTransfer(Transfer transfer)
        {
            _context.Transfers.Update(transfer); 
            await _context.SaveChangesAsync();
            return transfer;
        }
    }
}
