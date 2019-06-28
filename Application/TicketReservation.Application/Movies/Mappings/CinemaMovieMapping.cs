using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketReservation.Domain;

namespace TicketReservation.Application.Movies.Mappings
{
    internal sealed class CinemaMovieMapping : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder.ToTable("CinemaMovies");
            builder.HasKey(x => new { x.CinemaId, x.MovieId });

            builder.HasOne(x => x.Cinema).WithMany(x => x.Movies).HasForeignKey(x => x.CinemaId);

            builder.HasOne(x => x.Movie).WithMany().HasForeignKey(x => x.MovieId);
        }
    }
}