using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentSystem.API.Models
{
    public class PlayInTournament
    {
        [Key]
        public int PlayInId { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        [ForeignKey("Tournament")]
        public int? TournamentId { get; set; }
        public Tournament? Tournament { get; set; }
    }
}
