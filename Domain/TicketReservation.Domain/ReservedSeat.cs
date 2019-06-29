using System;

namespace TicketReservation.Domain
{
    public class ReservedSeat
    {
        public const int NumberOfRows = 20;
        public const int NumberOfSeatsPerRow = 30;

        public Guid Id { get; protected set; }
        public int Row { get; protected set; }
        public int Seat { get; protected set; }
        public Ticket Ticket { get; protected set; }

        protected ReservedSeat()
        {
        }

        internal ReservedSeat(Guid id, int row, int seat, Ticket ticket)
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

        public static ReservedSeat Create(int row, int seat, Ticket ticket)
        {
            return new ReservedSeat(Guid.NewGuid(), row, seat, ticket);
        }
    }
}