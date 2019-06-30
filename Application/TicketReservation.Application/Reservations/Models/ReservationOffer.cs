using TicketReservation.Application.Reservations.Models;

namespace TicketReservation.Application.Reservations.Requests
{
    public class ReservationOffer
    {
        public ReservationOfferRequest OfferRequest { get; set; }
        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            ReservationOffer other = obj as ReservationOffer;
            if (other is null)
                return false;

            return Price == other.Price
                && OfferRequest.Equals(other.OfferRequest);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Price.GetHashCode() * OfferRequest.GetHashCode()) ^ 1337;
            }
        }
    }
}