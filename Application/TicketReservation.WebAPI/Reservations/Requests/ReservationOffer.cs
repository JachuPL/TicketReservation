namespace TicketReservation.WebAPI.Reservations.Requests
{
    public class ReservationOffer
    {
        public ReservationOfferRequest OfferRequest { get; set; }
        public decimal Price { get; set; }
    }
}