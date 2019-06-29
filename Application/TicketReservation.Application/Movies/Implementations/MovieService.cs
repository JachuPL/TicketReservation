using System;
using System.Threading.Tasks;
using TicketReservation.Application.Common.Database;
using TicketReservation.Application.Movies.Interfaces;
using TicketReservation.Application.Movies.Models;
using TicketReservation.Domain;

namespace TicketReservation.Application.Movies.Implementations
{
    internal sealed class MovieService : IMovieService
    {
        private readonly TicketReservationContext _ctx;

        public MovieService(TicketReservationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(Guid movieId, CreateMovieRequest request)
        {
            Movie movie = MovieFactory.Create(movieId, request.Title);
            _ctx.Add(movie);
            await _ctx.SaveChangesAsync();
        }
    }
}