using System.Collections.Generic;
using dotnet_jwt_authentication.Models;
using dotnet_jwt_authentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt_authentication.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        // GET /users
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        //GET /users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user is null)
                return NotFound();
            return Ok(user);
        }
        
        //POST /users 
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            return _userService.CreateUser(user);
        }
        
        //DELETE /users/{id}
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
        
    }
}