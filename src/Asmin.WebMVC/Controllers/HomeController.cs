using Application.Entities.CustomEntities.Request.Home;
using Application.Entities.CustomEntities.Request.User;
using Application.Entities.CustomEntities.Response.Home;
using Application.Packages.Hashing.VIGENERE.Service;
using Asmin.WebMVC.Services.Rest.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace AES.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserApiService _userApiService;

        private readonly VigenereService _vigenereService;

        public HomeController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
            _vigenereService = new VigenereService();
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

        public IActionResult TextCryption()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TextCryption(VigenereRequest request)
        {
            var sb = new StringBuilder();

            sb.Append(request.Text);

            var model = new VigenereResponse
            {
                Key = request.Key,
                Mode = request.Mode,
                Text = request.Text
            };

            if (request.Mode)
            {
                model.Result = _vigenereService.Generate(ref sb, request.Key);

                return View("TextCryption", model);
            }

            model.Result = _vigenereService.VigenereDecrypt(ref sb, request.Key);
            return View("TextCryption", model);
        }
    }
}
