using Microsoft.Extensions.Configuration;
using System;
using TicketReservation.Application.Settings;

namespace TicketReservation.WebAPI.Extensions
{
    internal static class SettingsExtensions
    {
        public static JwtSettings GetJwtSettings(this IConfiguration configuration)
        {
            string key = configuration["jwt:Key"];
            string issuer = configuration["jwt:Issuer"];
            int expirationTimeInMinutes = int.Parse(configuration["jwt:ExpirationTimeInMinutes"]);
            return new JwtSettings(key, issuer, TimeSpan.FromMinutes(expirationTimeInMinutes));
        }
    }
}