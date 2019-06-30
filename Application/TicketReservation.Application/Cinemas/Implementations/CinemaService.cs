using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservation.Application.Cinemas.Interfaces;
using TicketReservation.Application.Cinemas.Models;
using TicketReservation.Application.Common.Database;
using TicketReservation.Application.Shows.Requests;
using TicketReservation.Domain;
using TicketReservation.Domain.Cinemas;
using TicketReservation.Domain.Movies;
using TicketReservation.Domain.Reservations;

namespace TicketReservation.Application.Cinemas.Implementations
{
    internal sealed class CinemaService : ICinemaService
    {
        private readonly TicketReservationContext _ctx;

        public CinemaService(TicketReservationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(Guid id, CreateCinemaRequest request)
        {
            Cinema cinema = CinemaFactory.Create(id, request.Name, request.City);
            _ctx.Add(cinema);
            await _ctx.SaveChangesAsync();
        }

        public async Task AddShow(Guid cinemaId, Guid showId, CreateShowRequest request)
        {
            Cinema cinema = await _ctx.Cinemas.Include(c => c.Shows).FirstOrDefaultAsync(c => c.Id == cinemaId);
            Movie movie = await _ctx.Movies.FindAsync(request.MovieId);

            Dictionary<Ticket, decimal> priceList = request.PriceList.ToDictionary(x => x.Kind, x => x.Price);
            Show show = ShowFactory.Create(showId, cinema, movie, request.Date, priceList);

            cinema.AddShow(show);
            await _ctx.SaveChangesAsync();
        }
    }
}