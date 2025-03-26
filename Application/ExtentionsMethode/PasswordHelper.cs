using System.Security.Cryptography;
using System.Text;

namespace Application.ExtentionsMethode;

public class PasswordHelper
{
    public static string EncodePasswordSha256(string pass)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] originalBytes = Encoding.UTF8.GetBytes(pass);
            byte[] encodedBytes = sha256.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
        }
    }
}