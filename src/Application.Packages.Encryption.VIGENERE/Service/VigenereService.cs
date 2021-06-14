using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Application.Packages.Encryption.Core.Service;
using Application.Packages.Hashing.Core.Service;


namespace Application.Packages.Hashing.VIGENERE.Service
{
    /// <summary>
    /// Vigenere servisi
    /// </summary>
    public class VigenereService
    {
      
        public string Generate(ref StringBuilder sb, string key)
        {
            for (int i = 0; i < sb.Length; i++)
                sb[i] = Char.ToUpper(sb[i]);

            key = key.ToUpper();
            int index = 0;

            for (int i = 0; i < sb.Length; i++)
            {
                if (Char.IsLetter(sb[i]))
                {
                    sb[i] = (char)(sb[i] + key[index] - 'A');
                    if (sb[i] > 'Z')
                        sb[i] = (char)(sb[i] - 'Z' + 'A' - 1);
                }

                index = index + 1 == key.Length ? 0 : index + 1;
            }

            return sb.ToString();
        }

        public string VigenereDecrypt(ref StringBuilder sb, string key)
        {
            for (int i = 0; i < sb.Length; i++)
                sb[i] = Char.ToUpper(sb[i]);

            key = key.ToUpper();
            int index = 0;

            for (int i = 0; i < sb.Length; i++)
            {
                if (Char.IsLetter(sb[i]))
                {
                    sb[i] = sb[i] >= key[index] ?
                        (char)(sb[i] - key[index] + 'A') :
                        (char)('A' + ('Z' - key[index] + sb[i] - 'A') + 1);
                }

                index = index + 1 == key.Length ? 0 : index + 1;
            }

            return sb.ToString();
        }
    }
}
