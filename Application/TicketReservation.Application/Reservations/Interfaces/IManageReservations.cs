using System;
using System.Threading.Tasks;
using TicketReservation.Application.Reservations.Requests;
using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Reservations.Interfaces
{
    public interface IManageReservations : IService
    {
        Task Add(Guid reservationId, Guid userId, ReservationOffer model);

        Task Delete(Guid id);

        Task MarkAsPaid(Guid id);
    }
}