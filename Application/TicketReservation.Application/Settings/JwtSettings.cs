using System;

namespace TicketReservation.Application.Settings
{
    public class JwtSettings
    {
        public TimeSpan ExpirationTime { get; private set; }
        public string Issuer { get; private set; }
        public string Key { get; private set; }

        public JwtSettings(string key, string issuer, TimeSpan expirationTime)
        {
            Key = key;
            Issuer = issuer;
            ExpirationTime = expirationTime;
        }
    }
}