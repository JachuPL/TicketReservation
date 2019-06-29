using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketReservation.Domain;

namespace TicketReservation.Application.Reservations.Mappings
{
    internal sealed class ReservedSeatMapping : IEntityTypeConfiguration<ReservedSeat>
    {
        public void Configure(EntityTypeBuilder<ReservedSeat> builder)
        {
            builder.ToTable("ReservedSeats");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ticket);
            builder.Property(x => x.Seat).IsRequired();
            builder.Property(x => x.Row).IsRequired();

            builder.HasOne<Reservation>().WithMany(x => x.ReservedSeats).HasForeignKey("ReservationId").IsRequired();
        }
    }
}