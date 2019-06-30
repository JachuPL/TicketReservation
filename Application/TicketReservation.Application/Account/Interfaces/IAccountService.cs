using System.Threading.Tasks;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Account.Interfaces
{
    public interface IAccountService : IService
    {
        Task<JwtDto> LoginAsync(string login, string password);
    }
}