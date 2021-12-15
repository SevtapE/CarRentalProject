using Business.Abstract;
using Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
           var result= _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result);
               
            }
           var accessToken= _authService.CreateAccessToken(result.Data);

            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }
            return BadRequest(accessToken);

        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
          
            if (userExists.Success)
            {
                return BadRequest(userExists);

            }
            var result = _authService.Register(userForRegisterDto);
            var accessToken = _authService.CreateAccessToken(result.Data);

            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }
            return BadRequest(accessToken);

        }

    }
}
