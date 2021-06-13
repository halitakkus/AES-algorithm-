using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;
using Application.Entities.CustomEntities.Request.User;
using Application.Entities.CustomEntities.Response.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Rest.UserService
{
    public interface IUserApiService
    {
        /// <summary>
        /// Kullanıcının giriş yapması için kullanılan yordam.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<DataResult<UserLoginResponse>> LoginAsync(UserLoginRequest loginRequest);

        /// <summary>
        /// Tüm kullanıcıları getirin.
        /// </summary>
        /// <returns></returns>
        Task<DataResult<List<User>>> GetListAsync();

        /// <summary>
        /// Yeni bir kullanıcı ekleyin.
        /// </summary>
        /// <param name="insertUserRequest"></param>
        /// <returns></returns>

        Task<Result> AddAsync(InsertUserRequest insertUserRequest);

        /// <summary>
        /// Var olan bir kullanıcıyı güncelleştirin.
        /// </summary>
        /// <param name="updateUserRequest"></param>
        /// <returns></returns>

        Task<Result> UpdateAsync(UpdateUserRequest updateUserRequest);

        /// <summary>
        /// Tüm kullanıcı sayısını alın.
        /// </summary>
        /// <returns></returns>

        Task<DataResult<int>> GetCountAsync();
    }
}
