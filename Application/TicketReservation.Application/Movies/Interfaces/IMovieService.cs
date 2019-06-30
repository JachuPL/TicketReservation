using System;
using System.Threading.Tasks;
using TicketReservation.Application.Movies.Models;
using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Movies.Interfaces
{
    public interface IMovieService : IService
    {
        Task Add(Guid movieId, CreateMovieRequest request);
    }
}