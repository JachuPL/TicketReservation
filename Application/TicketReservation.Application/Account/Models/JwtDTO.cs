namespace TicketReservation.Application.Account.Models
{
    public class JwtDto
    {
        public long Expires { get; set; }
        public string Token { get; set; }
    }
}