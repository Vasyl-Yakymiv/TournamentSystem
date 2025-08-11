using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.API.Dto.Transfer
{
    public class UpdateTransferDto
    {
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int FromTeamId { get; set; }
        [Required]
        public int ToTeamId { get; set; }
        [Range(0, double.MaxValue)]
        public decimal TransferFee { get; set; }
    }
}
