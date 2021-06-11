using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;
using Application.Entities.CustomEntities.Request.User;
using Application.Entities.CustomEntities.Response.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Rest.UserService
{
    public interface IUserApiService
    {
        Task<DataResult<UserLoginResponse>> LoginAsync(UserLoginRequest loginRequest);

        Task<DataResult<List<User>>> GetListAsync();

        Task<IResult> AddAsync(InsertUserRequest insertUserRequest);

        Task<IResult> UpdateAsync(UpdateUserRequest updateUserRequest);

        Task<DataResult<int>> GetCountAsync();
    }
}
