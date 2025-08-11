namespace TournamentSystem.API.Dto.Player
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Image {  get; set; }
    }
}
