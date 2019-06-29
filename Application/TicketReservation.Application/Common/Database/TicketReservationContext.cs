using Microsoft.EntityFrameworkCore;
using System;
using TicketReservation.Application.Cinemas.Mappings;
using TicketReservation.Application.Encryption;
using TicketReservation.Application.Movies.Mappings;
using TicketReservation.Application.Reservations.Mappings;
using TicketReservation.Application.Shows.Mappings;
using TicketReservation.Domain;
using TicketReservation.Domain.Cinemas;

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
            Database.EnsureCreated();
        }

        public TicketReservationContext(DbContextOptions options, IEncrypt encrypter) : base(options)
        {
            _encrypter = encrypter;
            Database.EnsureCreated();
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
            User admin = CreateUser("admin", "admin12345", "admin@ticketres.pl", "777888999", "Admin", "Adminowski", Role.Administrator);
            User cashier = CreateUser("cashier", "cashier12345", "cashier@ticketres.pl", "777888999", "Cashier", "Cashmirowski", Role.Cashier);
            User user = CreateUser("user", "user12345", "user@ticketres.pl", "777888999", "Pan", "Użyszkodnik", Role.Customer);

            builder.Entity<User>().HasData(admin, cashier, user);
        }

        private User CreateUser(string login, string password, string email, string phone, string firstName,
            string lastName, Role role)
        {
            var salt = _encrypter.GetSalt(password);
            var passwordHash = _encrypter.GetHash(password, salt);
            return new User(Guid.NewGuid(), login, passwordHash, salt, email, phone, firstName, lastName, role);
        }
    }
}