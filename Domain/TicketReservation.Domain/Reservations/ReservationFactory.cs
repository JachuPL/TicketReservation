using System;
using TicketReservation.Domain.Users;

namespace TicketReservation.Domain.Reservations
{
    public static class ReservationFactory
    {
        public static Reservation Create(Guid reservationId, User user)
        {
            return new Reservation(reservationId, user.Email, user.Phone, user.FirstName, user.LastName);
        }
    }
}