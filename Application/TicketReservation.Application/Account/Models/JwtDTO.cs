namespace TicketReservation.Application.Account.Models
{
    public class JwtDTO
    {
        public long Expires { get; set; }
        public string Token { get; set; }
    }
}