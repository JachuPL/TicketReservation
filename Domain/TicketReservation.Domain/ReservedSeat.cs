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

            if (Row < 1 || Row > 20)
            {
                throw new ArgumentException(nameof(row));
            }
            Row = row;
            
            if (Seat < 1 || Seat > 30)
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