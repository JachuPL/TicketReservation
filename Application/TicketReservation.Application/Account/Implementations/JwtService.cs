using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Extensions;
using TicketReservation.Application.Settings;
using TicketReservation.Application.Account.Interfaces;
using TicketReservation.Domain;

namespace TicketReservation.Application.Account.Implementations
{
    internal sealed class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public JwtDTO CreateToken(Guid userId, Role role, string login)
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

            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                 SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDTO
            {
                Expires = expires.ToTimestamp(),
                Token = token
            };
        }
    }
}