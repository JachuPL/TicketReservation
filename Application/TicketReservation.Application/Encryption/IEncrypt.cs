using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Encryption
{
    public interface IEncrypt : IService
    {
        string GetHash(string value, string salt);

        string GetSalt(string value);
    }
}