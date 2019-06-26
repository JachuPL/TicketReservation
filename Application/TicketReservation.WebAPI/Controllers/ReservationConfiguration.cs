using System;
using System.Collections.Generic;
using TicketReservation.Domain;

namespace TicketReservation.WebAPI.Controllers
{
    public class ReservationConfiguration
    {
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public Guid ShowId { get; set; }
        public List<Place> Tickets { get; set; } = new List<Place>();
    }

    public class Place
    {
        public Ticket Ticket { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}