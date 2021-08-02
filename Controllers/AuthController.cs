using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnet_jwt_authentication.Models;
using dotnet_jwt_authentication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_jwt_authentication.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost]
        public ActionResult<User> AuthenticateUser([FromBody] LoginUser userCreds)
        {
            var user = _userService.Authenticate(userCreds.Username, userCreds.Password);
            if (user is null)
                return BadRequest();
            return Ok(user);
        }
    }
}