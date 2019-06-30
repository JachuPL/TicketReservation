using System;

namespace TicketReservation.Domain.Reservations
{
    public class ReservedSeat
    {
        public const int NumberOfRows = 20;
        public const int NumberOfSeatsPerRow = 30;

        public Guid Id { get; private set; }
        public int Row { get; private set; }
        public int Seat { get; private set; }
        public Ticket Ticket { get; private set; }

        protected ReservedSeat()
        {
        }

        private ReservedSeat(Guid id, int row, int seat, Ticket ticket)
        {
            Id = id;

            if (row < 1 || row > NumberOfRows)
            {
                throw new ArgumentException(nameof(row));
            }
            Row = row;

            if (seat < 1 || seat > NumberOfSeatsPerRow)
            {
                throw new ArgumentException(nameof(seat));
            }
            Seat = seat;

            Ticket = ticket;
        }

        public ReservedSeat(int row, int seat, Ticket ticket) : this(Guid.NewGuid(), row, seat, ticket)
        {
        }
    }
}