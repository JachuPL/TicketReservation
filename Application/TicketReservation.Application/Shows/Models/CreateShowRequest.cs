using System;
using System.Collections.Generic;
using TicketReservation.Domain;

namespace TicketReservation.Application.Shows.Requests
{
    public class CreateShowRequest
    {
        public Guid MovieId { get; set; }
        public DateTime Date { get; set; }
        public List<TicketPrice> PriceList { get; set; } = new List<TicketPrice>();
    }

    public class TicketPrice
    {
        public Ticket Kind { get; set; }
        public decimal Price { get; set; }
    }
}