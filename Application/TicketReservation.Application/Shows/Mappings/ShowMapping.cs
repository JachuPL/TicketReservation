using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using TicketReservation.Domain;

namespace TicketReservation.Application.Shows.Mappings
{
    internal sealed class ShowMapping : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.ToTable("Shows");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Movie).WithMany().HasForeignKey("MovieId").IsRequired();
            builder.HasOne(x => x.Cinema).WithMany(x => x.Shows).HasForeignKey("CinemaId").IsRequired();

            builder.Property(x => x.Date).HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.PriceList)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<Ticket, decimal>>(v));
        }
    }
}