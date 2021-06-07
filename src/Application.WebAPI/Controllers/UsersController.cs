
using System.Threading.Tasks;
using Application.Business.Abstract;
using Application.Entities.CustomEntities.Request.User;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var userDataResult = await _userManager.GetListAsync();

            if (!userDataResult.IsSuccess)
            {
                return BadRequest(userDataResult);
            }

            return Ok(userDataResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDataResult = await _userManager.GetByIdAsync(id);

            if (!userDataResult.IsSuccess)
            {
                return BadRequest(userDataResult);
            }

            return Ok(userDataResult);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InsertUserRequest insertUserRequest)
        {
            var checkUserAdded = await _userManager.AddAsync(insertUserRequest);

            if (!checkUserAdded.IsSuccess)
            {
                BadRequest(checkUserAdded);
            }

            return Ok(checkUserAdded);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest updateUserRequest)
        {
            var checkUserUpdated = await _userManager.UpdateAsync(updateUserRequest);

            if (!checkUserUpdated.IsSuccess)
            {
                return BadRequest(checkUserUpdated);
            }

            return Ok(checkUserUpdated);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkUserRemoved = await _userManager.RemoveAsync(id);

            if (!checkUserRemoved.IsSuccess)
            {
                return BadRequest(checkUserRemoved);
            }

            return Ok(checkUserRemoved);
        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCount()
        {
            var checkUsersCount = await _userManager.GetCountAsync();

            if (!checkUsersCount.IsSuccess)
            {
                return BadRequest(checkUsersCount);
            }

            return Ok(checkUsersCount);
        }
    }
}