using Asmin.WebMVC.Services.Rest.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserApiService _userApiService;

        public HomeController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var usersResult = await _userApiService.GetListAsync();

            return View(usersResult.Data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
