using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketReservation.Domain.Cinemas
{
    public class Cinema
    {
        public const int MaxNameLength = 100;
        public const int MaxCityLength = 100;
        public Guid Id { get; private set; }
        public HashSet<Show> Shows { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }

        protected Cinema()
        {
            Shows = new HashSet<Show>();
        }

        internal Cinema(Guid id, string name, string city)
        {
            Id = id;

            ValidateName(name);
            Name = name;

            ValidateCity(city);
            City = city;
            Shows = new HashSet<Show>();
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length > MaxNameLength)
                throw new ArgumentOutOfRangeException(nameof(name));
        }

        private void ValidateCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException(nameof(city));

            if (city.Length > MaxCityLength)
                throw new ArgumentOutOfRangeException(nameof(city));
        }

        public void AddShow(Show show)
        {
            if (HasAlreadyShow(show))
            {
                return;
            }

            Shows?.Add(show);
        }

        private bool HasAlreadyShow(Show show)
        {
            return Shows?.Any(x => x.Id == show?.Id) == true;
        }

        public void RemoveShow(Show show)
        {
            var foundShow = Shows?.FirstOrDefault(x => x.Id == show?.Id);
            if (foundShow is null) return;
            if (!HasAlreadyShow(foundShow)) ;
            Shows.Remove(foundShow);
        }
    }
}