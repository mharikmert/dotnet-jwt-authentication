using System.Collections.Generic;
using dotnet_jwt_authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt_authentication.Services
{
    public interface IUserService
    {
        public User GetUserById(int id);
        public List<User> GetAllUsers();
        public User CreateUser(User user);
        public User UpdateUser(int id, User user);
        public void DeleteUser(int id);
        public User Authenticate(string username, string password);
    }
}