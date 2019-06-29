using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketReservation.Domain;
using TicketReservation.Domain.Cinemas;

namespace TicketReservation.Application.Cinemas.Mappings
{
    internal sealed class CinemaMapping : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.ToTable("Cinemas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City).HasMaxLength(Cinema.MaxCityLength).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(Cinema.MaxNameLength).IsRequired();
        }
    }
}