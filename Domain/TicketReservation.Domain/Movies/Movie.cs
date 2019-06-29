using System;

namespace TicketReservation.Domain.Movies
{
    public class Movie
    {
        public const int MaxMovieName = 100;

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        protected Movie()
        {
        }

        internal Movie(Guid id, string name)
        {
            Id = id;
            ValidateName(name);
            Name = name;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (name.Length > MaxMovieName)
                throw new ArgumentOutOfRangeException(nameof(name));
        }
    }
}