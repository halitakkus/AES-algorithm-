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
using Application.Packages.Encryption.Core.Service;
using Application.Entities.CustomEntities.Response.User;

namespace Application.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;
        private readonly IHashService _hashService;
        private readonly IEncryptionService _encryptionService;
        private readonly IValidator<User> _userValidator;

        public UserManager(IUserDal userDal, IValidator<User> userValidator, 
            IHashService hashService, IEncryptionService encryptionService)
        {
            _userDal = userDal;
            _hashService = hashService;
            _userValidator = userValidator;
            _encryptionService = encryptionService;
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
            //Şifre geriye dönülemeyeceği için sha256 ile hash uygulanmıştır.
            user.Password = _hashService.Generate(user.Password);

            //Diğer bilgiler ise geriye dönülebileceği için AES ile şifrelenmiştir.
            user.FirstName = _encryptionService.Generate(user.FirstName);
            user.LastName = _encryptionService.Generate(user.LastName);
            user.Email = _encryptionService.Generate(user.Email);

            //son durumda hazırlanmış nesne veritabanına kaydedilir.
            await _userDal.AddAsync(user);

            return new SuccessResult(ResultMessages.UserAdded);
        }

        public IDataResult<UserLoginResponse> Login(UserLoginRequest loginRequest)
        {
            var userLoginResponse = new UserLoginResponse();

            var hashedPassword = _hashService.Generate(loginRequest.Password);

            var cryptedEmail = _encryptionService.Generate(loginRequest.Email);

            var user = _userDal.GetUser(cryptedEmail, hashedPassword);

            if (user == null)
            {
                return new ErrorDataResult<UserLoginResponse>(userLoginResponse, ResultMessages.UserNotFound);
            }

            userLoginResponse.User = user;

            return new SuccessDataResult<UserLoginResponse>(userLoginResponse);
        }


        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetByIdAsync(id);
            return new SuccessDataResult<User>(user);
        }

        public async Task<IDataResult<List<User>>> GetListAsync()
        {
            var users = await _userDal.GetListAsync();

            for (int i = 0; i < users.Count(); i++)
            {
                users[i].Email = _encryptionService.Decryption(users[i].Email, Keys.AesKey);
                users[i].FirstName = _encryptionService.Decryption(users[i].FirstName, Keys.AesKey);
                users[i].LastName = _encryptionService.Decryption(users[i].LastName, Keys.AesKey);
            }

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

            updateUserRequest.FirstName = _encryptionService.Generate(updateUserRequest.FirstName);
            updateUserRequest.LastName = _encryptionService.Generate(updateUserRequest.LastName);
            updateUserRequest.Email = _encryptionService.Generate(updateUserRequest.Email);

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
