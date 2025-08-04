using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.API.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string  Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? ImageUrl { get; set; }
    }
}
