﻿using Application.Core.Entities.Concrete;
using Application.DataAccess.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccess.Abstract
{
    /// <summary>
    /// User repository interface.
    /// </summary>
    public interface IUserDal : IRepository<User, int>
    {
        /// <summary>
        /// Returns user by email and password.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Hashed password.</param>
        /// <returns></returns>
        User GetUser(string email, string password);
    }
}
