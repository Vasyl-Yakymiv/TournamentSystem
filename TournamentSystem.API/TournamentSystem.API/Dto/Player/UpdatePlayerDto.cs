using System.ComponentModel.DataAnnotations.Schema;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Dto.Player
{
    public class UpdatePlayerDto
    {
        public int? TeamId { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
    }
}
