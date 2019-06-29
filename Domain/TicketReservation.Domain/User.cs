using System;

namespace TicketReservation.Domain
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public Guid Id { get; private set; }
        public string LastName { get; set; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public string Phone { get; set; }
        public Role Role { get; private set; }

        public User(Guid id, string login, string passwordHash, string passwordSalt, string email, string phone, string firstName, string lastName)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;

            Role = Role.Customer;
        }

        public User(Guid id, string login, string passwordHash, string passwordSalt, string email, string phone, string firstName, string lastName, Role role) : 
            this(id, login, passwordHash, passwordSalt, email, phone, firstName, lastName)
        {
            Role = role;
        }

        protected User()
        {
        }
    }
}