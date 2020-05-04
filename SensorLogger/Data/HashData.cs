using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SensorLogger.Data
{
    public class HashData : IHashData
    {
        string IHashData.ComputeHashSha512(string password, string salt)
        {
            byte[] toBeHashed = Encoding.UTF8.GetBytes(password + salt);

            using (var sha512 = SHA512.Create())
            {
                return Convert.ToBase64String(sha512.ComputeHash(toBeHashed));
            }
        }
    }
}
