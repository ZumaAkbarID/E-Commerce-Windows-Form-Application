using System.Security.Cryptography;
using System.Text;

namespace EcommerceDB
{
    internal class PasswordHasher
    {
        public static string BuatMD5Hash(string input)
        {
            // MD5 SHA 1 itu 1 way hash
            // Buat MD5 HASH
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // ubah byte array ke hex array
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                // buat hex string lower case daripada uppercase tambahkan parameter "X2" biar jadi hexa
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }
    }
}
