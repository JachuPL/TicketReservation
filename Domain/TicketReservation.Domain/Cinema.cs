using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketReservation.Domain
{
    public class Cinema
    {
        public Guid Id { get; protected set; }
        public HashSet<Show> Shows { get; protected set; }
        public string Name { get; protected set; }
        public string City { get; protected set; }

        protected Cinema()
        {
            Shows = new HashSet<Show>();
        }

        internal Cinema(Guid id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
            Shows = new HashSet<Show>();
        }

        public void AddShow(Show show)
        {
            if (Shows.Any(x => x.Id == show.Id))
            {
                return;
            }

            Shows.Add(show);
        }

        public void RemoveShow(Show show)
        {
            var foundShow = Shows.FirstOrDefault(x => x.Id == show.Id);
            if (foundShow is null) return;
            Shows.Remove(foundShow);
        }
    }
}