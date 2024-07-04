using System.Security.Cryptography;
using System.Text;

namespace Application
{
    public class Hash
    {
        public static string SHA256Hash(string input, string salt = "")
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input + salt);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
