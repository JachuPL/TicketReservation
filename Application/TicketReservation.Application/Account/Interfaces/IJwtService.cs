using System;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Shared;
using TicketReservation.Domain.Users;

namespace TicketReservation.Application.Account.Interfaces
{
    public interface IJwtService : IService
    {
        JwtDto CreateToken(Guid userId, Role role, string login);
    }
}