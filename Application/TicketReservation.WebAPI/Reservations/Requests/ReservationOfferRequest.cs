using System;
using System.Collections.Generic;

namespace TicketReservation.WebAPI.Reservations.Requests
{
    public class ReservationOfferRequest
    {
        public Guid ShowId { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();
    }
}