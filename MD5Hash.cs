using System;
using System.Linq;
using System.Text;

namespace ITG.Utilities
{
    public static class MD5
    {
        public static string GetHash(System.IO.Stream stream)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return String.Concat(md5.ComputeHash(stream).Select(b => b.ToString("X2")).ToArray());
        }

        public static string GetHashV2(System.IO.Stream stream)
        {
                // Use input string to calculate MD5 hash
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] hashBytes  = md5.ComputeHash (stream);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                     sb.Append (hashBytes[i].ToString ("X2"));
                     // To force the hex string to lower-case letters instead of
                     // upper-case, use the following line instead:
                     // sb.Append(hashBytes[i].ToString("x2")); 
                }
                return sb.ToString();
        }
    }
}
