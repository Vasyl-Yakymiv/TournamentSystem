using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentSystem.API.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        [ForeignKey(nameof(TeamA))]
        public int TeamAId { get; set; }
        public Team TeamA { get; set; }

        [ForeignKey(nameof(TeamB))]
        public int TeamBId { get; set; }
        public Team TeamB { get; set; }
        public int? ScoreA { get; set; }
        public int? ScoreB { get; set; }
        public DateTime MatchDate { get; set; }
        [ForeignKey(nameof(WinnerTeam))]
        public int? WinnerTeamId { get; set; }
        public Team WinnerTeam { get; set; }
        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
