using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservation.Application.Common.Database;
using TicketReservation.Application.Reservations.Interfaces;
using TicketReservation.Application.Reservations.Models;
using TicketReservation.Application.Reservations.Requests;
using TicketReservation.Domain.Reservations;
using TicketReservation.Domain.Shows;

namespace TicketReservation.Application.Reservations.Implementations
{
    internal sealed class ReservationsQuerier : IQueryReservations
    {
        private readonly TicketReservationContext _ctx;

        public ReservationsQuerier(TicketReservationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ReservationOffer> GetReservationOffer(ReservationOfferRequest request)
        {
            Show show = await _ctx.Shows.Include(s => s.Reservations).FirstOrDefaultAsync(s => s.Id == request.ShowId);
            if (IsAnyPlaceReservedAlready(request, show))
            {
                throw new Exception($"One or more of requested places are already reserved.");
            }

            Dictionary<Ticket, int> requestedTickets = request.Places.GroupBy(x => x.Ticket).ToDictionary(x => x.Key, x => x.Count());
            decimal price = show.EvaluateReservationPrice(requestedTickets);

            return new ReservationOffer()
            {
                OfferRequest = request,
                Price = price
            };
        }

        private static bool IsAnyPlaceReservedAlready(ReservationOfferRequest request, Show show)
        {
            return request.Places.Any(p => show.IsPlaceReserved(p.Row, p.Seat));
        }

        public async Task<IEnumerable<Place>> GetAvailableSeats(Guid showId)
        {
            Show show = await _ctx.Shows.Include(x => x.Reservations).ThenInclude(y => y.ReservedSeats).FirstOrDefaultAsync(x => x.Id == showId);
            if (show is null)
            {
                throw new KeyNotFoundException(nameof(showId));
            }
            var allReservedSeats = show.Reservations.SelectMany(x => x.ReservedSeats);
            return GetAvailableSeats(allReservedSeats);
        }

        private static List<Place> GetAvailableSeats(IEnumerable<ReservedSeat> reservedSeats)
        {
            var allPossiblePlaces = from row in Enumerable.Range(1, ReservedSeat.NumberOfRows)
                                    from seat in Enumerable.Range(1, ReservedSeat.NumberOfSeatsPerRow)
                                    select new { row, seat };

            var availableSeats = allPossiblePlaces.Where(x => reservedSeats.Any(z => z.Row != x.row && z.Seat != x.seat));

            return availableSeats.Select(x => new Place
            {
                Row = x.row,
                Seat = x.seat
            }).ToList();
        }
    }
}