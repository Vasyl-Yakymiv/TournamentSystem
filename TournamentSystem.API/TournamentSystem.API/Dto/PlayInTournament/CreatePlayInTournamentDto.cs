using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentSystem.API.Dto.PlayInTournament
{
    public class CreatePlayInTournamentDto
    {
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
    }
}
