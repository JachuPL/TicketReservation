using System;

namespace TicketReservation.Domain
{
    public class User
    {
        public Guid Id { get; private set; }

        public string Login { get; private set; }

        public string PasswordHash { get; private set; }

        public string PasswordSalt { get; private set; }

        public Role Role { get; private set; }

        public User(Guid id, string login, string passwordHash, string passwordSalt)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;

            Role = Role.Customer;
        }

        public User(Guid id, string login, string passwordHash, string passwordSalt, Role role) : this(id, login,
            passwordHash, passwordSalt)
        {
            Role = Role.Customer;
        }

        protected User()
        {
        }

        
    }
}