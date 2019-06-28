using System;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Account.Interfaces
{
    public interface IJwtService : IService
    {
        JwtDTO CreateToken(Guid userId, string login);
    }
}