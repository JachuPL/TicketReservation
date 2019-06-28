using System;
using System.Collections.Generic;

namespace TicketReservation.Domain
{
    public class Reservation
    {
        public Guid Id { get; protected set; }
        public string UserEmail { get; protected set; }
        public string UserPhone { get; protected set; }
        public string UserFirstName { get; protected set; }
        public string UserLastName { get; protected set; }
        public HashSet<ReservedSeat> ReservedSeats { get; protected set; }

        protected Reservation()
        {
            ReservedSeats = new HashSet<ReservedSeat>();
        }

        internal Reservation(Guid id, string userEmail, string userPhone, string userFirstName, string userLastName, HashSet<ReservedSeat> reservedSeats)
        {
            Id = id;
            UserEmail = userEmail;
            UserPhone = userPhone;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            ReservedSeats = reservedSeats;
        }

        internal Reservation(Guid id, HashSet<ReservedSeat> reservedSeats)
        {
            Id = id;
            ReservedSeats = reservedSeats;
        }
    }
}