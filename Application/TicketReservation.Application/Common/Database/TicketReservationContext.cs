using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TicketReservation.Application.Cinemas.Mappings;
using TicketReservation.Application.Movies.Mappings;
using TicketReservation.Application.Reservations.Mappings;
using TicketReservation.Application.Shows.Mappings;
using TicketReservation.Domain;
using TicketReservation.Domain.Identity;

namespace TicketReservation.Application.Common.Database
{
    public class TicketReservationContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Show> Shows { get; set; }

        protected TicketReservationContext()
        {
        }

        public TicketReservationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CinemaMapping());
            builder.ApplyConfiguration(new CinemaMovieMapping());
            builder.ApplyConfiguration(new MovieMapping());
            builder.ApplyConfiguration(new ReservationMapping());
            builder.ApplyConfiguration(new ReservedSeatMapping());
            builder.ApplyConfiguration(new ShowMapping());

            ConfigureIdentity(builder);
        }

        private static void ConfigureIdentity(ModelBuilder builder)
        {
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<RoleClaim>().ToTable("RoleClaims");
            builder.Entity<User>().ToTable("Users");
            builder.Entity<UserLogin>().ToTable("UserLogins");
            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserToken>().ToTable("UserTokens");
            builder.Entity<UserClaim>().ToTable("UserClaims");

            Role administrator = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Administrator",
                NormalizedName = "Administrator"
            };

            Role cashier = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Cashier",
                NormalizedName = "Cashier"
            };

            Role customer = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Customer",
                NormalizedName = "Customer"
            };
            builder.Entity<Role>().HasData(administrator, cashier, customer);
        }
    }
}