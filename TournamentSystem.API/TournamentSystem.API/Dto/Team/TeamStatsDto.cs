namespace TournamentSystem.API.Dto.Team
{
    public class TeamStatsDto
    {
        public int TeamId { get; set; }
        public int TeamMatches { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
