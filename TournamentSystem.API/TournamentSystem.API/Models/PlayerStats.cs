using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentSystem.API.Models
{
    public class PlayerStats
    {
        [Key]
        public int StatsId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
      
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }

        public double KD => (double)Kills / Deaths;
        public int Headshots { get; set; }
        public double HeadshotPercentage { get; set; }

        public double AverageDamagePerRound { get; set; }
        public double Rating { get; set; }
    }
}
