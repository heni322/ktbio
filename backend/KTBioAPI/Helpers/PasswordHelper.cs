using BCrypt.Net;

namespace KTBioAPI.Helpers
{
    /// <summary>
    /// Helper class for secure password hashing and verification using BCrypt
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hash a password using BCrypt with work factor of 12
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <returns>BCrypt hashed password</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty", nameof(password));

            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        /// <summary>
        /// Verify a password against a BCrypt hash
        /// </summary>
        /// <param name="password">Plain text password to verify</param>
        /// <param name="hash">BCrypt hash to verify against</param>
        /// <returns>True if password matches hash, false otherwise</returns>
        public static bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}
