﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketReservation.Domain.Movies;

namespace TicketReservation.Application.Movies.Mappings
{
    internal sealed class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(Movie.MaxMovieName).IsRequired();
        }
    }
}