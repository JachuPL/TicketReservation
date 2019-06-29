using System;
using System.Collections.Generic;

namespace TicketReservation.Domain
{
    public static class ShowFactory
    {
        public static Show Create(Guid id, Cinema cinema, Movie movie, DateTime date, Dictionary<Ticket, decimal> priceList)
        {
            //validate everything

            return new Show(id, cinema, movie, date, priceList);
        }
    }
}
