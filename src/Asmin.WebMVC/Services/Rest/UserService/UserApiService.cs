using AES.WebMVC.Services.Rest.Base;
using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;
using Application.Entities.CustomEntities.Request.User;
using Application.Entities.CustomEntities.Response.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Rest.UserService
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpService _httpService;

        public UserApiService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<DataResult<UserLoginResponse>> LoginAsync(UserLoginRequest loginRequest)
        {
            return _httpService.PostAsync<DataResult<UserLoginResponse>>("/users/login", loginRequest);
        }

        public Task<DataResult<List<User>>> GetListAsync()
        {
            return _httpService.GetAsync<DataResult<List<User>>>("/users");
        }

        public Task<DataResult<int>> GetCountAsync()
        {
            return _httpService.GetAsync<DataResult<int>>("/users/count");
        }

        public Task<Result> AddAsync(InsertUserRequest insertUserRequest)
        {
            return _httpService.PostAsync<Result>("/users/add", insertUserRequest);
        }

        public Task<Result> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            return _httpService.PostAsync<Result>("/users/update", updateUserRequest);
        }
    }
}
