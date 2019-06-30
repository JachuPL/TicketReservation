using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservation.Application.Common.Database;
using TicketReservation.Application.Common.Mail;
using TicketReservation.Application.Reservations.Interfaces;
using TicketReservation.Application.Reservations.Models;
using TicketReservation.Application.Reservations.Requests;
using TicketReservation.Domain.Reservations;
using TicketReservation.Domain.Shows;
using TicketReservation.Domain.Users;

namespace TicketReservation.Application.Reservations.Implementations
{
    internal sealed class ReservationsManager : IManageReservations
    {
        private readonly TicketReservationContext _ctx;
        private readonly IQueryReservations _reservationsQuerier;
        private readonly ISendEmails _emailSender;

        public ReservationsManager(TicketReservationContext ctx, IQueryReservations reservationsQuerier, ISendEmails emailSender)
        {
            _ctx = ctx;
            _reservationsQuerier = reservationsQuerier;
            _emailSender = emailSender;
        }

        public async Task Add(Guid reservationId, Guid userId, ReservationOffer request)
        {
            var offer = await _reservationsQuerier.GetReservationOffer(request.OfferRequest);
            if (!offer.Equals(request))
            {
                throw new Exception("Offer has expired.");
            }

            if (AnyPlaceIsInvalid(request.OfferRequest.Places))
            {
                throw new Exception("Invalid place configuration.");
            }

            Show show = await _ctx.Shows.Include(s => s.Reservations).FirstOrDefaultAsync(s => s.Id == request.OfferRequest.ShowId);
            if (show is null)
            {
                throw new KeyNotFoundException(nameof(request.OfferRequest.ShowId));
            }

            User user = await _ctx.Users.FindAsync(userId);
            if (user is null)
            {
                throw new KeyNotFoundException(nameof(userId));
            }

            Reservation reservation = ReservationFactory.Create(reservationId, user);
            AddPlacesToReservation(request.OfferRequest.Places, reservation);
            show.AddReservation(reservation);

            await _ctx.SaveChangesAsync();

            _emailSender.Send(new Email()); //TODO
        }

        private void AddPlacesToReservation(List<Place> places, Reservation reservation)
        {
            places.ForEach(place => reservation.AddSeat(place.Row, place.Seat, place.Ticket));
        }

        private bool AnyPlaceIsInvalid(List<Place> places)
        {
            return places.Any(x => x.Row > ReservedSeat.NumberOfRows || x.Seat > ReservedSeat.NumberOfSeatsPerRow
                            || x.Row < 1 || x.Seat < 1);
        }

        public async Task Delete(Guid id)
        {
            Show show = await FindShowByReservationId(id);
            if (show is null) return;
            show.RemoveReservationById(id);
            await _ctx.SaveChangesAsync();
        }

        private async Task<Show> FindShowByReservationId(Guid id)
        {
            return await _ctx.Shows.Include(x => x.Reservations).ThenInclude(x => x.ReservedSeats).Where(s => s.Reservations.Any(r => r.Id == id)).FirstOrDefaultAsync();
        }

        public async Task MarkAsPaid(Guid id)
        {
            Show show = await FindShowByReservationId(id);
            if (show is null) return;
            Reservation reservation = show.Reservations.First(x => x.Id == id);
            reservation.MarkAsPaid();
            await _ctx.SaveChangesAsync();
        }
    }
}