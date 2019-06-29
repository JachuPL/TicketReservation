using System;
using System.Security.Claims;

namespace TicketReservation.WebAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetGuid(this ClaimsPrincipal user)
        {
            return user?.Identity?.IsAuthenticated == true ? Guid.Parse(user.Identity.Name) : Guid.Empty;
        }
    }
}