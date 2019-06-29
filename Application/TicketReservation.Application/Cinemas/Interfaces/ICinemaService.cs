using System;
using System.Threading.Tasks;
using TicketReservation.Application.Cinemas.Models;
using TicketReservation.Application.Shared;
using TicketReservation.Application.Shows.Requests;

namespace TicketReservation.Application.Cinemas.Interfaces
{
    public interface ICinemaService : IService
    {
        Task Add(Guid id, CreateCinemaRequest request);

        Task AddShow(Guid cinemaId, Guid showId, CreateShowRequest model);
    }
}