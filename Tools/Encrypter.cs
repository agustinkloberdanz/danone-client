using System.Security.Cryptography;

namespace danone_client.Tools
{
    public class Encrypter
    {
        public static void EncryptString(string text, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();

            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
        }

        public static bool ValidateText(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(hash);
        }
    }
}