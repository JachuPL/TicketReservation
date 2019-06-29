using TicketReservation.Domain;

namespace TicketReservation.WebAPI.Reservations.Requests
{
    public class Place
    {
        public Ticket Ticket { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}