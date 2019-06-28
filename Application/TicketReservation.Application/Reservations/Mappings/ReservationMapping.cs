using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketReservation.Domain;

namespace TicketReservation.Application.Reservations.Mappings
{
    internal sealed class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(x => x.Id);

            builder.HasOne<Show>().WithMany(x => x.Reservations).HasForeignKey("ShowId");

            builder.Property(x => x.UserEmail).HasMaxLength(100);
            builder.Property(x => x.UserFirstName).HasMaxLength(100);
            builder.Property(x => x.UserLastName).HasMaxLength(100);
            builder.Property(x => x.UserPhone).HasMaxLength(20);
        }
    }
}