using System;
using System.Collections.Generic;
using System.Text;

namespace TicketReservation.Domain
{
    public class CinemaMovie
    {
        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }

        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
    }
}
