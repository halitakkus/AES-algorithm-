using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.Hashing.Core.Service;
using AppMD5 = System.Security.Cryptography.MD5;

namespace Application.Packages.Hashing.MD5.Service
{
    /// <summary>
    /// MD5 hash servisi oluşturuldu.
    /// </summary>
    public class MD5HashService : IHashService
    {
        public string Generate(string plainText)
        {
            using (AppMD5 md5Hash = AppMD5.Create())
            {
               
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

              
                StringBuilder sBuilder = new StringBuilder();
                
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public bool Compare(string hashedText, string plainText)
        {
            return Generate(plainText) == hashedText;
        }
    }
}
