using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.Hashing.Core.Service;
using AppMD5 = System.Security.Cryptography.MD5;

namespace Application.Packages.Hashing.MD5.Service
{
    /// <summary>
    /// MD5 hash service.
    /// </summary>
    public class MD5HashService : IHashService
    {
        public string Generate(string plainText)
        {
            using (AppMD5 md5Hash = AppMD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        public bool Compare(string hashedText, string plainText)
        {
            return Generate(plainText) == hashedText;
        }
    }
}
