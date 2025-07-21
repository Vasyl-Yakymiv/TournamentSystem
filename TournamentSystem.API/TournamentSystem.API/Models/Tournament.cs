using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.API.Models
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PrizeMoney { get; set; }
        public string Logo { get; set; }
    }
}
