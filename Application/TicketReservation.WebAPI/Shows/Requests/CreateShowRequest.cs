using System;
using System.Collections.Generic;

namespace TicketReservation.WebAPI.Shows.Requests
{
    public class CreateShowRequest
    {
        public Guid MovieId { get; set; }
        public Guid CinemaId { get; set; }
        public DateTime Date { get; set; }
        public List<TicketPrice> PriceList { get; set; } = new List<TicketPrice>();
    }

    public class TicketPrice
    {
        public TicketKind Kind { get; set; }
        public decimal Price { get; set; }
    }

    public enum TicketKind
    {
        Normal,
        Students,
        Senior
    }
}