using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentSystem.API.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
    }
}
