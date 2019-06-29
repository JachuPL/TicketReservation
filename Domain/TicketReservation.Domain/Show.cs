using System;
using System.Collections.Generic;
using System.Linq;
using TicketReservation.Domain.Cinemas;
using TicketReservation.Domain.Movies;

namespace TicketReservation.Domain
{
    public class Show
    {
        public Cinema Cinema { get; protected set; }
        public DateTime Date { get; protected set; }
        public Guid Id { get; protected set; }
        public Movie Movie { get; protected set; }
        public Dictionary<Ticket, decimal> PriceList { get; protected set; }
        public HashSet<Reservation> Reservations { get; protected set; }

        internal Show(Guid id, Cinema cinema, Movie movie, DateTime date, Dictionary<Ticket, decimal> pricelist)
        {
            Id = id;
            Cinema = cinema;
            Movie = movie;
            Date = date;
            PriceList = pricelist;
            Reservations = new HashSet<Reservation>();
        }

        protected Show()
        {
            Reservations = new HashSet<Reservation>();
        }

        public void AddReservation(Reservation reservation)
        {
            if (DateTime.Now > Date)
            {
                throw new Exception("This show has already started.");
            }

            if (reservation.WasPlacedViaWebsite && DateTime.Now > Date.AddMinutes(-30))
            {
                throw new Exception("This reservation cannot be placed, because show starts in less than 30 minutes.");
            }

            foreach (var reservedSeat in reservation.ReservedSeats)
            {
                if (IsPlaceReserved(reservedSeat.Row, reservedSeat.Seat))
                {
                    throw new Exception($"Seat {reservedSeat.Seat} in row {reservedSeat.Row} is already reserved.");
                }
            }

            Reservations.Add(reservation);
        }

        public decimal EvaluateReservationPrice(Dictionary<Ticket, int> requestedTickets)
        {
            return requestedTickets.Sum(t => PriceList[t.Key] * t.Value);
        }

        public bool IsPlaceReserved(int row, int seat)
        {
            return Reservations.Any(r => r.ReservedSeats.Any(s => s.Row == row && s.Seat == seat));
        }

        public void RemoveReservationById(Guid reservationId)
        {
            Reservations.RemoveWhere(r => r.Id == reservationId);
        }
    }
}