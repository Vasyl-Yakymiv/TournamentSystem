using TournamentSystem.API.Dto.Player;

namespace TournamentSystem.API.Dto.Team
{
    public class GetAllTeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public List<GetAllPlayerDto> Players { get; set; }
    }
}
