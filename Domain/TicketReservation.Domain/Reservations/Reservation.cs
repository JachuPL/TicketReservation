using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketReservation.Domain.Reservations
{
    public class Reservation
    {
        public Guid Id { get; private set; }
        public string UserEmail { get; private set; }
        public string UserPhone { get; private set; }
        public string UserFirstName { get; private set; }
        public string UserLastName { get; private set; }
        public HashSet<ReservedSeat> ReservedSeats { get; private set; }
        public bool IsPaid { get; private set; }

        protected Reservation()
        {
            ReservedSeats = new HashSet<ReservedSeat>();
        }

        internal Reservation(Guid id, string userEmail, string userPhone, string userFirstName, string userLastName)
        {
            Id = id;
            UserEmail = userEmail;
            UserPhone = userPhone;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            IsPaid = false;
        }

        internal Reservation(Guid id, HashSet<ReservedSeat> reservedSeats, bool isPaid)
        {
            Id = id;
            ReservedSeats = reservedSeats;
            IsPaid = isPaid;
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
        }

        public bool WasPlacedViaWebsite => UserEmail != null;

        public void AddSeat(int row, int seat, Ticket ticket)
        {
            if (ReservedSeats.Any(x => x.Row == row && x.Seat == seat))
                return;

            ReservedSeats.Add(new ReservedSeat(row, seat, ticket));
        }
    }
}