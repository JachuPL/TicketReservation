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
using TicketReservation.Domain;

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

            HashSet<ReservedSeat> reservedSeats = MapPlaces(request.OfferRequest.Places);

            Reservation reservation = ReservationFactory.Create(reservationId, show, user, reservedSeats);
            show.AddReservation(reservation);

            await _ctx.SaveChangesAsync();

            _emailSender.Send(new Email()); //TODO
        }

        private HashSet<ReservedSeat> MapPlaces(List<Place> places)
        {
            HashSet<ReservedSeat> reservedSeats = new HashSet<ReservedSeat>();
            places.ForEach(place =>
            {
                ReservedSeat seat = ReservedSeat.Create(place.Row, place.Seat, place.Ticket);
                reservedSeats.Add(seat);
            });

            return reservedSeats;
        }

        private bool AnyPlaceIsInvalid(List<Place> places)
        {
            return places.Any(x => x.Row > Place.NumberOfRows || x.Seat > Place.NumberOfSeatsPerRow
            || x.Row < 1 || x.Seat < 1);
        }

        public async Task Delete(Guid id)
        {
            Show show = await _ctx.Shows.Where(s => s.Reservations.Any(r => r.Id == id)).FirstOrDefaultAsync();
            show.RemoveReservationById(id);
            await _ctx.SaveChangesAsync();
        }
    }
}