using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentSystem.API.Models
{
    public class Transfer
    {
        [Key]
        public int TransferId { get; set; }
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey(nameof(FromTeam))]
        public int? FromTeamId { get; set; }
        public Team? FromTeam { get; set; }

        [ForeignKey(nameof(ToTeam))]
        public int? ToTeamId { get; set; }
        public Team? ToTeam { get; set; }

        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }

    }
}
