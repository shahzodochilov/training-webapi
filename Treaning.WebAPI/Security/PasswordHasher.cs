namespace Treaning.WebAPI.Security
{
    public static class PasswordHasher
    {
        private const string _key = "SalomSalom112233";
        public static (string Hash, string Salt) Hash(string password)
        {
            string salt = Guid.NewGuid().ToString();
            string hash = BCrypt.Net.BCrypt.HashPassword(salt + password + _key);
            return (Hash: hash, Salt: salt);
        }

        public static bool Verify(string password, string salt, string oldHash)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(salt + password + _key);
            return oldHash == hash;
        }
    }
}
