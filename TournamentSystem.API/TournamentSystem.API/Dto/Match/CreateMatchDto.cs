using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.API.Dto.Match
{
    public class CreateMatchDto
    {
        [Required]
        public int TeamAId { get; set; }

        [Required]
        public int TeamBId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public int TournamentId { get; set; }
    }
}
