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
        /// Id değerine göre kullanıcı getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IDataResult<User>> GetByIdAsync(int id);
        /// <summary>
        /// Kullanıc listesini getirir
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<List<User>>> GetListAsync();
        /// <summary>
        /// Kullanıcı ekler
        /// </summary>
        /// <param name="insertUserRequest"></param>
        /// <returns></returns>
        Task<IResult> AddAsync(InsertUserRequest insertUserRequest);
        /// <summary>
        /// Veritabanından kullanıcıyı günceller
        /// </summary>
        /// <param name="updateUserRequest"></param>
        /// <returns></returns>
        Task<IResult> UpdateAsync(UpdateUserRequest updateUserRequest);
        /// <summary>
        /// Kullanıcıyı veritabanından kaldırır
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        Task<IResult> RemoveAsync(int id);
     
        /// <summary>
        /// Kullanıcıların sayısını getirir
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<int>> GetCountAsync();


        /// <summary>
        /// Örnek yapmak amacıyla bir girişdenemesi
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        IDataResult<UserLoginResponse> Login(UserLoginRequest loginRequest);
    }
}
