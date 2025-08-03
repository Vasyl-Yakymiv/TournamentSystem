namespace TournamentSystem.API.Dto.Tournament
{
    public class UpdateTournamentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PrizeMoney { get; set; }
        public string Logo { get; set; }
    }
}
