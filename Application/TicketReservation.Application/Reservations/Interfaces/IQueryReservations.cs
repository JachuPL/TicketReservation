using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketReservation.Application.Reservations.Models;
using TicketReservation.Application.Reservations.Requests;
using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Reservations.Interfaces
{
    public interface IQueryReservations : IService
    {
        Task<IEnumerable<Place>> GetAvailableSeats(Guid showId);

        Task<ReservationOffer> GetReservationOffer(ReservationOfferRequest configuration);
    }
}