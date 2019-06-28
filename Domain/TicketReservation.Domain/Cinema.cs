using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketReservation.Domain
{
    public class Cinema
    {
        public Guid Id { get; protected set; }
        public HashSet<CinemaMovie> Movies { get; protected set; }
        public string Name { get; protected set; }
        public string City { get; protected set; }

        protected Cinema()
        {
            Movies = new HashSet<CinemaMovie>();
        }

        internal Cinema(Guid id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
            Movies = new HashSet<CinemaMovie>();
        }

        public void AddMovie(Movie movie)
        {
            if (Movies.Any(x => x.MovieId == movie.Id))
            {
                return;
            }

            Movies.Add(new CinemaMovie { Cinema = this, Movie = movie });
        }

        public void RemoveMovie(Movie movie)
        {
            var foundMovie = Movies.FirstOrDefault(x => x.MovieId == movie.Id);
            if (foundMovie is null) return;
            Movies.Remove(foundMovie);
        }
    }
}