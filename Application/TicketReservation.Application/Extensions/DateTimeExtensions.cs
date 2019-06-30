using System;

namespace TicketReservation.Application.Extensions
{
    internal static class DateTimeExtensions
    {
        public static long ToTimestamp(this DateTime dateTime)
        {
            var epochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var time = dateTime.Subtract(new TimeSpan(epochDate.Ticks));

            return time.Ticks / 10000;
        }
    }
}