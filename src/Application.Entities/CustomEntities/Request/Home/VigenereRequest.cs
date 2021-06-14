using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities.CustomEntities.Request.Home
{
    /// <summary>
    ///
    /// </summary>
    public class VigenereRequest
    {
        /// <summary>
        /// Vigenere algoritması için şifrelenecek text değer.
        /// 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Algoritama için ihtiyacı olan key değeri.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// şifreleme veya deşifreleme modu için.
        /// </summary>
        public bool Mode { get; set; }
    }
}
