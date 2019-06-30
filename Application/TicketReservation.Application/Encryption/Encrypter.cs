using System;
using System.Security.Cryptography;

namespace TicketReservation.Application.Encryption
{
    internal class Encrypter : IEncrypt
    {
        private const int DeriveBytesIterationsCount = 10000;
        private const int SaltSize = 40;

        public string GetHash(string input, string salt)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Can not generate hash from an empty input.", nameof(input));
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Can not use an empty salt from hashing input.", nameof(input));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(input, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public string GetSalt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Can not generate salt from an empty password.", nameof(password));
            }
            if (password.Length < 6)
            {
                throw new Exception("Password must contain at least 6 characters.");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }

            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}