using dotnet_jwt_authentication.Services;
using NUnit.Framework;

namespace dotnet_jwt_authentication.Tests
{
    public class AuthControllerTests
    {
        private UserService _userService; 
        [SetUp]
        public void Setup()
        {
            _userService = new UserService();
        }

        [Test]
        public void TestAuthenticateUser()
        {
            Assert.Null(_userService.GetUserById(1).Token); // User token is null at first 
            
            _userService.Authenticate("username1", "password"); // authenticate the user 
            
            Assert.NotNull(_userService.GetUserById(1).Token); // JWT must be generated 
            
            Assert.Null(_userService.GetUserById(1).Password); // password must be assigned as null 
            
        }
        
    }
}