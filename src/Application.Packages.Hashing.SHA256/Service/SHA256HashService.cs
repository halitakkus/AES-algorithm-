﻿using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.Hashing.Core.Service;
using AppSHA256 = System.Security.Cryptography.SHA256;

namespace Application.Packages.Hashing.SHA256.Service
{
    /// <summary>
    /// SHA256 hash servisi.
    /// </summary>
    public class SHA256HashService : IHashService
    {
        public string Generate(string plainText)
        {
            using (AppSHA256 sha256Hash = AppSHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool Compare(string hashedText, string plainText)
        {
            return Generate(plainText) == hashedText;
        }
    }
}
