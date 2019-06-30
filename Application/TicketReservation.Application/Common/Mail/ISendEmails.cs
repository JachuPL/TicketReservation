using TicketReservation.Application.Shared;

namespace TicketReservation.Application.Common.Mail
{
    public interface ISendEmails : IService
    {
        void Send(Email message);
    }
}