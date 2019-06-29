using System;
using System.Collections.Generic;

namespace TicketReservation.Domain
{
    public static class ReservationFactory
    {
        public static Reservation Create(Guid reservationId, Show show, User user, HashSet<ReservedSeat> reservedSeats)
        {
            return new Reservation(reservationId, user.Email, user.Phone, user.FirstName, user.LastName, reservedSeats);
        }
    }
}