using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Encryption
{
    public interface IEncrypt : IService
    {
        string GetHash(string input, string salt);

        string GetSalt(string password);
    }
}