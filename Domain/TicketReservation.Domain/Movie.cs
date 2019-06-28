using System;
using System.Collections.Generic;

namespace TicketReservation.Domain
{
    public class Movie
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public HashSet<Show> Shows { get; protected set; }

        protected Movie()
        {
            Shows = new HashSet<Show>();
        }

        internal Movie(Guid id, string name)
        {
            Id = id;
            Name = name;
            Shows = new HashSet<Show>();
        }

        public void AddShow(Show show)
        {
            if (Shows.Contains(show))
            {
                return;
            }

            Shows.Add(show);
        }
    }
}