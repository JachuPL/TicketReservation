using System;
using System.Collections.Generic;

namespace TicketReservation.Domain
{
    public class Show
    {
        public Guid Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public HashSet<Reservation> Reservations { get; protected set; }
        public Movie Movie { get; protected set; }
        public Cinema Cinema { get; protected set; }
        public Dictionary<Ticket, decimal> PriceList { get; protected set; }

        protected Show()
        {
            Reservations = new HashSet<Reservation>();
        }

        internal Show(Guid id, Cinema cinema, Movie movie, DateTime date, Dictionary<Ticket, decimal> pricelist)
        {
            Id = id;
            Cinema = cinema;
            Movie = movie;
            Date = date;
            PriceList = pricelist;
            Reservations = new HashSet<Reservation>();
        }

        public void AddReservation(Reservation reservation)
        {
            // sprawdzamy
        }

        public void SetPricePerTicket(Ticket ticket, decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));
            PriceList[ticket] = price;
        }
    }
}