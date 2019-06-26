using System;
using System.Collections.Generic;

namespace TicketReservation.WebAPI.Reservations.Requests
{
    public class ReservationConfiguration
    {
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public Guid ShowId { get; set; }
        public List<Place> Tickets { get; set; } = new List<Place>();
    }
}