using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TicketReservation.Application.Account.Interfaces;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Common.Database;
using TicketReservation.Application.Encryption;

namespace TicketReservation.Application.Account.Implementations
{
    internal sealed class AccountService : IAccountService
    {
        private readonly TicketReservationContext _ctx;
        private readonly IEncrypt _encrypter;
        private readonly IJwtService _jwtService;

        public AccountService(TicketReservationContext ctx, IEncrypt encrypter, IJwtService jwtService)
        {
            _ctx = ctx;
            _encrypter = encrypter;
            _jwtService = jwtService;
        }

        public async Task<JwtDTO> LoginAsync(string login, string password)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.PasswordSalt);
            if (user.PasswordHash != hash)
            {
                throw new Exception("Invalid credentials");
            }

            var token = _jwtService.CreateToken(user.Id, login);
            return token;
        }
    }
}
