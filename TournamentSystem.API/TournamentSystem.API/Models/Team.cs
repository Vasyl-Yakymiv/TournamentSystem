namespace TournamentSystem.API.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public float PlayerAgeAvg { get; set; }
        public string TeamLogo { get; set; }

        public ICollection<Player>? Players { get; set; }
    }
}
