using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken=_tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var checkForLogin = _userService.GetByMail(userForLoginDto.Email);
            if (checkForLogin.Data==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);

            }
           if(! HashingHelper.VerifyPasswordHash(userForLoginDto.Password, checkForLogin.Data.PasswordHash, checkForLogin.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(checkForLogin.Data, Messages.PasswordError);
            }

            return new SuccessDataResult<User>(checkForLogin.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var checkForRegister = _userService.GetByMail(userForRegisterDto.Email);
            if (checkForRegister.Data!=null)
            {
                return new ErrorDataResult<User>(checkForRegister.Data, Messages.UserAlreadyExists);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);

            var user = new User { 
                 FirstName=userForRegisterDto.FirstName,
                 LastName=userForRegisterDto.LastName,
                 Email=userForRegisterDto.Email,
                 PasswordHash=passwordHash,
                 PasswordSalt=passwordSalt,
                  Status=true
            
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);

               
        }

        public IResult UserExists(string email)
        {
           if(_userService.GetByMail(email).Data != null)
            {
                return new SuccessResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult(Messages.NotExists);
           
        }
    }
}
