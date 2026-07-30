using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NBE
{
    public class hasher
    {
        public static string getHash(string word) {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash returns a byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(word));

                // Convert byte array to a lower-case hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string hashString = builder.ToString();

                return hashString;
            }
}
    }
}