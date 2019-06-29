using System;
using Microsoft.EntityFrameworkCore;
using TicketReservation.Application.Cinemas.Mappings;
using TicketReservation.Application.Movies.Mappings;
using TicketReservation.Application.Reservations.Mappings;
using TicketReservation.Application.Shows.Mappings;
using TicketReservation.Domain;
using TicketReservation.Application.Encryption;

namespace TicketReservation.Application.Common.Database
{
    public class TicketReservationContext : DbContext
    {
        private readonly IEncrypt _encrypter;
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected TicketReservationContext()
        {
        }

        public TicketReservationContext(DbContextOptions options, IEncrypt encrypter) : base(options)
        {
            _encrypter = encrypter;
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
            builder.ApplyConfiguration(new MovieMapping());
            builder.ApplyConfiguration(new ReservationMapping());
            builder.ApplyConfiguration(new ReservedSeatMapping());
            builder.ApplyConfiguration(new ShowMapping());

            SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            const string adminPassword = "admin12345";
            var adminSalt = _encrypter.GetSalt(adminPassword);
            var adminHash = _encrypter.GetHash(adminPassword, adminSalt);
            User admin = new User(Guid.NewGuid(), "admin", adminHash, adminSalt, "admin@ticketres.pl", "777888999", "Admin", "Adminowski", Role.Administrator);

            const string cashierPassword = "cashier12345";
            var cashierSalt = _encrypter.GetSalt(cashierPassword);
            var cashierHash = _encrypter.GetHash(cashierPassword, cashierSalt);
            User cashier = new User(Guid.NewGuid(), "cashier", cashierHash, cashierSalt, "cashier@ticketres.pl", "777888999", "Cashier", "Cashmirowski", Role.Cashier);

            const string customerPassword = "user12345";
            var customerSalt = _encrypter.GetSalt(customerPassword);
            var customerHash = _encrypter.GetHash(customerPassword, customerSalt);
            User user = new User(Guid.NewGuid(), "user", customerHash, customerSalt, "user@ticketres.pl", "777888999", "Pan", "Użyszkodnik", Role.Customer);

            builder.Entity<User>().HasData(admin, cashier, user);
        }
    }
}