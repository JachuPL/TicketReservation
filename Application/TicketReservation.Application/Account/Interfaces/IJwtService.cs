using System;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Shared;
using TicketReservation.Domain;

namespace TicketReservation.Application.Account.Interfaces
{
    public interface IJwtService : IService
    {
        JwtDTO CreateToken(Guid userId, Role role, string login);
    }
}