using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IAuthService
    {
        IResult Register(UserForRegisterDto userForRegisterDto);
        IResult Login(UserForLoginDto userForLoginDto);
        IDataResult<bool> UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
