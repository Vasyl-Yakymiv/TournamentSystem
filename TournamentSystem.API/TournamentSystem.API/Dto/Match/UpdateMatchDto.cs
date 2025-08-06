using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.API.Dto.Match
{
    public class UpdateMatchDto
    {
        public int TeamAId { get; set; }
        public int TeamBId { get; set; }
        public int? ScoreA { get; set; }
        public int? ScoreB { get; set; }
        public DateTime MatchDate { get; set; }
        public int? WinnerTeamId { get; set; }
    }
}
