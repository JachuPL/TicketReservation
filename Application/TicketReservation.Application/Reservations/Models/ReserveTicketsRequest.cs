using System;
using System.Collections.Generic;
using TicketReservation.Application.Reservations.Models;

namespace TicketReservation.Application.Reservations.Requests
{
    public class ReserveTicketsRequest
    {
        public Guid ShowId { get; set; }
        public List<Place> Tickets { get; set; } = new List<Place>();
    }
}