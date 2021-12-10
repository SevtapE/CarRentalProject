using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public IResult Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IResult Register(UserForRegisterDto userForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> UserExists(string email)
        {
            throw new NotImplementedException();
           
        }
    }
}
