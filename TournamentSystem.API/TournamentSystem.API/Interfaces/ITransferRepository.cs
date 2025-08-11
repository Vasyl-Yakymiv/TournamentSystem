using TournamentSystem.API.Dto.Transfer;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Interfaces
{
    public interface ITransferRepository
    {
        Task<IEnumerable<TransferDto>> GetAll();
        Task<Transfer> GetTransferById(int id);
        Task<IEnumerable<TransferDto>> GetTransferByTeam(int teamId);
        Task<IEnumerable<Transfer>> GetTransferByPlayer(int playerId);
        Task<Transfer> CreateTransfer(Transfer transfer);
        Task<Transfer> UpdateTransfer(Transfer transfer);
        Task DeleteTransfer(int id);
    }
}
