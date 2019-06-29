namespace TicketReservation.Application.Settings
{
    public class JwtSettings
    {
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }

        public JwtSettings(string key, string issuer, int expiryMinutes)
        {
            Key = key;
            Issuer = issuer;
            ExpiryMinutes = expiryMinutes;
        }
    }
}