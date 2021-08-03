using dotnet_jwt_authentication.Models;
using dotnet_jwt_authentication.Services;
using NUnit.Framework;

namespace dotnet_jwt_authentication.Tests
{
    public class UserControllerTests
    {
        private UserService _userService; 
        [SetUp]
        public void SetUp()
        {
            _userService = new UserService();
        }
        [Test]
        public void TestGetUserById()
        {
            Assert.AreEqual("user1", _userService.GetUserById(1).Name);
        }

        [Test]
        public void TestGetAllUsers()
        {
            Assert.IsNotEmpty(_userService.GetAllUsers());
            // Assert.True(_userService.GetAllUsers().Count is 4);
        }

        [Test]
        public void TestCreateUser()
        {
            _userService.CreateUser(new User{Name = "testUser"});
            Assert.NotNull(_userService.GetAllUsers().Find( tempUser => tempUser.Name == "testUser"));
        }

        [Test]
        public void TestDeleteUser()
        {
            _userService.DeleteUser(1);
            Assert.Null(_userService.GetUserById(1));
        }
    }
}