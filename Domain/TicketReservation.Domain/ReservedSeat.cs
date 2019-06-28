using System;

namespace TicketReservation.Domain
{
    public class ReservedSeat
    {
        public Guid Id { get; protected set; }
        public int Row { get; protected set; }
        public int Column { get; protected set; }
        public Ticket Ticket { get; protected set; }
        public bool IsPaid { get; protected set; }

        internal ReservedSeat(Guid id, int row, int column, Ticket ticket, bool isPaid)
        {
            Id = id;
            Row = row;
            Column = column;
            Ticket = ticket;
            IsPaid = isPaid;
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
        }
    }
}