using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Packages.Hashing.Core.Service
{
    /// <summary>
    /// Çekirdek bir hash servisi oluşturuldu. Diğer tüm algoritmalar buradan türeyecektir.
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Şifrelemek için:
        /// </summary>
        /// <param name="plainText">Şifrelenecek text</param>
        /// <returns></returns>
        string Generate(string plainText);
        /// <summary>
        /// Kontrol etmek için
        /// </summary>
        /// <param name="hashedText">Şifreli text</param>
        /// <param name="plainText">Şifrelenecek text</param>
        /// <returns></returns>
        bool Compare(string hashedText, string plainText);
    }
}
