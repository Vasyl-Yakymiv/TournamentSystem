using System.ComponentModel.DataAnnotations;

namespace TournamentSystem.API.Dto.News
{
    public class UpdateNewsDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
    }
}
