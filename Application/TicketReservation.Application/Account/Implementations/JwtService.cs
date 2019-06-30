using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketReservation.Application.Account.Interfaces;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Extensions;
using TicketReservation.Application.Settings;
using TicketReservation.Domain.Users;

namespace TicketReservation.Application.Account.Implementations
{
    internal sealed class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public JwtDto CreateToken(Guid userId, Role role, string login)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,  now.ToTimestamp().ToString(), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, role.ToString()),
            };

            DateTime expirationTime = now + _jwtSettings.ExpirationTime;

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                 SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expirationTime,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Expires = expirationTime.ToTimestamp(),
                Token = token
            };
        }
    }
}