using Application.Entities.CustomEntities.Request;
using Application.Entities.CustomEntities.Request.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities.CustomEntities.Response.Home
{
    /// <summary>
    ///
    /// </summary>
    public class VigenereResponse:VigenereRequest
    {
        /// <summary>
        /// Vigenere algoritması için şifrelenmiş sonuç.
        /// </summary>
        public string Result { get; set; }
    }
}
