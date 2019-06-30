using System;
using System.Collections.Generic;
using TicketReservation.Domain.Cinemas;
using TicketReservation.Domain.Movies;
using TicketReservation.Domain.Reservations;

namespace TicketReservation.Domain.Shows
{
    public static class ShowFactory
    {
        public static Show Create(Guid id, Cinema cinema, Movie movie, DateTime date, Dictionary<Ticket, decimal> priceList)
        {
            return new Show(id, cinema, movie, date, priceList);
        }
    }
}