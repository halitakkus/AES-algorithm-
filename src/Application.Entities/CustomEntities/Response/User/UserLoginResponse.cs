using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities.CustomEntities.Response.User
{
    /// <summary>
    /// User login response.
    /// </summary>
    public class UserLoginResponse
    {
        /// <summary>
        /// Current user information.
        /// </summary>
        public Core.Entities.Concrete.User User { get; set; }
    }
}
