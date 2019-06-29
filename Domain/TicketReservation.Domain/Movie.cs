using System;

namespace TicketReservation.Domain
{
    public class Movie
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        protected Movie()
        {
        }

        internal Movie(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}