using System;

namespace TicketReservation.Domain
{
    public class User
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public Guid Id { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public string Phone { get; private set; }
        public Role Role { get; private set; }

        public User(Guid id, string login, string passwordHash, string passwordSalt, string email, string phone, string firstName, string lastName)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Email = email;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;

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