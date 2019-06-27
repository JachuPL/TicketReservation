namespace TicketReservation.Application.Common.Mail
{
    public interface ISendEmails
    {
        void Send(Email message);
    }
}