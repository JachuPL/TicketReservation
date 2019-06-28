using Microsoft.Extensions.Configuration;
using TicketReservation.Application.Settings;

namespace TicketReservation.WebAPI.Extensions
{
    internal static class SettingsExtensions
    {
        public static JwtSettings GetJwtSettings(this IConfiguration configuration)
        {
            var key = configuration["jwt:Key"];
            var issuer = configuration["jwt:Issuer"];
            int expiryMinutes = int.Parse(configuration["jwt:ExpiryMinutes"]);
            var settings = new JwtSettings(key, issuer, expiryMinutes);
            return settings;
        }
    }
}