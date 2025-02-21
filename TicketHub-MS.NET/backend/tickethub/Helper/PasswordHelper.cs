namespace tickethub.Helper
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)  
        {
            Console.WriteLine(BCrypt.Net.BCrypt.HashPassword(password, workFactor: 11, enhancedEntropy: false));
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 11, enhancedEntropy: false);  

        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        }
    }
}
