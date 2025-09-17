namespace TournamentSystem.API.Dto.PlayerStats
{
    public class CreatePlayerStatsDto
    {
        public int PlayerId { get; set; }              
        public int Kills { get; set; }           
        public int Deaths { get; set; }          
        public int Assists { get; set; }         
        public int Headshots { get; set; }
        public double HeadshotPercentage { get; set; }
        public double AverageDamagePerRound { get; set; }
        public double Rating { get; set; }
    }
}
