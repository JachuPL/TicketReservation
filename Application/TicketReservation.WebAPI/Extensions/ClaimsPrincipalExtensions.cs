using System;
using System.Security.Claims;

namespace TicketReservation.WebAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetGuid(this ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated == true)
            {
                return Guid.Parse(user.Identity.Name);
            }

            return Guid.Empty;
        }
    }
}