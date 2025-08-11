namespace TournamentSystem.API.Dto.Transfer
{
    public class TransferDto
    {
        public int TransferId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int FromTeamId { get; set; }
        public string FromTeamName { get; set; }
        public int ToTeamId { get; set; }
        public string ToTeamName { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal TransferFee { get; set; }
    }
}
