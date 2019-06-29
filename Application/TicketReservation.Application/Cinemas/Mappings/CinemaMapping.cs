using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketReservation.Domain;

namespace TicketReservation.Application.Cinemas.Mappings
{
    internal sealed class CinemaMapping : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.ToTable("Cinemas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}