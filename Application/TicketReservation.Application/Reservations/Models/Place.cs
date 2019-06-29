using TicketReservation.Domain;

namespace TicketReservation.Application.Reservations.Models
{
    public class Place
    {
        public int Row { get; set; }
        public int Seat { get; set; }
        public Ticket Ticket { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            Place other = obj as Place;
            if (other is null)
                return false;

            return Row == other.Row
                && Seat == other.Seat
                && Ticket == other.Ticket;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Row.GetHashCode() * Seat.GetHashCode() * Ticket.GetHashCode() ^ 1337;
            }
        }
    }
}