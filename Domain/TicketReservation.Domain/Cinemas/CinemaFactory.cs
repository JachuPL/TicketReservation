using System;

namespace TicketReservation.Domain.Cinemas
{
    public static class CinemaFactory
    {
        public static Cinema Create(Guid id, string name, string city)
        {
            return new Cinema(id, name, city);
        }
    }
}