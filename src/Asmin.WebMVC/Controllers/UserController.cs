using Application.Entities.CustomEntities.Request.User;
using Application.Entities.CustomEntities.Response.User;
using Asmin.WebMVC.Services.Rest.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebMVC.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserApiService _userApiService;

        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var usersResult = await _userApiService.GetListAsync();

            return View(usersResult.Data);
        }

        public async Task<IActionResult> AddAsync(InsertUserRequest insertUserRequest)
        {
            var usersResult = await _userApiService.AddAsync(insertUserRequest);

            return View(usersResult);
        }

        public async Task<IActionResult> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            var usersResult = await _userApiService.UpdateAsync(updateUserRequest);

            return View(usersResult);
        }

        public async Task<IActionResult> LoginAsync(UserLoginRequest userLoginRequest)
        {
            var usersResult = await _userApiService.LoginAsync(userLoginRequest);

            return View(usersResult.Data);
        }
    }
}
