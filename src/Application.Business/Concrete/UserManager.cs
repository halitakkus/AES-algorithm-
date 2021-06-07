using Application.Business.Abstract;
using Application.Core.Constants.Messages;
using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;
using Application.DataAccess.Abstract;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entities.CustomEntities.Request.User;
using Application.Packages.AOP.Aspects.Exception;
using Application.Packages.AOP.Aspects.Transaction;
using Application.Packages.Hashing.Core.Service;

namespace Application.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;
        private readonly IHashService _hashService;
        private readonly IValidator<User> _userValidator;

        public UserManager(IUserDal userDal, IValidator<User> userValidator, IHashService hashService)
        {
            _userDal = userDal;
            _hashService = hashService;
            _userValidator = userValidator;
        }

        [ExceptionAspect]
        [UnitOfWorkAspect]
        public async Task<IResult> AddAsync(InsertUserRequest insertUserRequest)
        {
            var user = new User
            {
                FirstName = insertUserRequest.FirstName,
                LastName = insertUserRequest.LastName,
                Email = insertUserRequest.Email,
                Password = insertUserRequest.Password
            };

            var validationResult = await _userValidator.ValidateAsync(user);

            if (!validationResult.IsValid)
            {
                var firstErrorMessage = validationResult.Errors.Select(failure => failure.ErrorMessage).FirstOrDefault();
                return new ErrorResult(firstErrorMessage);
            }

            user.Password = _hashService.Generate(user.Password);

            await _userDal.AddAsync(user);
            return new SuccessResult(ResultMessages.UserAdded);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(user);
        }

        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            var users = await _userDal.GetListAsync();
            return new SuccessDataResult<List<User>>(users);
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            var currentUser = await _userDal.GetByIdAsync(id);

            if (currentUser == null)
            {
                return new ErrorResult(ResultMessages.UserNotFound);
            }

            await _userDal.RemoveAsync(currentUser);

            return new SuccessResult(ResultMessages.UserRemoved);
        }

        public async Task<IResult> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            var currentUser = await _userDal.GetByIdAsync(updateUserRequest.Id);

            if (currentUser == null)
            {
                return new ErrorResult(ResultMessages.UserNotFound);
            }

            currentUser.FirstName = updateUserRequest.FirstName;
            currentUser.LastName = updateUserRequest.LastName;
            currentUser.Email = updateUserRequest.Email;

            await _userDal.UpdateAsync(currentUser);

            return new SuccessResult(ResultMessages.UserUpdated);
        }

        public async Task<IDataResult<int>> GetCountAsync()
        {
            var usersCount = await _userDal.GetCountAsync();
            return new SuccessDataResult<int>(usersCount);
        }
    }
}
