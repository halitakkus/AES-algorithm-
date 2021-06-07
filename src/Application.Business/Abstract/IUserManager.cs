using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.CustomEntities.Request.User;
using Application.Entities.CustomEntities.Response.User;

namespace Application.Business.Abstract
{
    public interface IUserManager
    {
        /// <summary>
        /// Get user by specified id value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IDataResult<User>> GetByIdAsync(int id);
        /// <summary>
        /// Get user list.
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<List<User>>> GetListAsync();
        /// <summary>
        /// Insert new user to database.
        /// </summary>
        /// <param name="insertUserRequest"></param>
        /// <returns></returns>
        Task<IResult> AddAsync(InsertUserRequest insertUserRequest);
        /// <summary>
        /// Update user from database.
        /// </summary>
        /// <param name="updateUserRequest"></param>
        /// <returns></returns>
        Task<IResult> UpdateAsync(UpdateUserRequest updateUserRequest);
        /// <summary>
        /// Remove user from database.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IResult> RemoveAsync(int id);
     
        /// <summary>
        /// It returns users count.
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<int>> GetCountAsync();
    }
}
