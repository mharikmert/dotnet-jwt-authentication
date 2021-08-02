using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using dotnet_jwt_authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_jwt_authentication.Services
{
    public class UserService : IUserService

    {
        private readonly List<User> _users = new List<User>
        {
            // In memory users 
            new User{Id = 1, Name = "user1", Surname = "surname1", Username = "username1", Password = "password"},
            new User{Id = 2, Name = "user2", Surname = "surname2", Username = "username2", Password = "password"},
            new User{Id = 3, Name = "user3", Surname = "surname3", Username = "username3", Password = "password"},
            new User{Id = 4, Name = "user4", Surname = "surname4", Username = "username4", Password = "password"}
        };
        
        
        public User GetUserById(int id)
        {
             return _users.Find(tempUser => tempUser.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User CreateUser(User user)
        {
            _users.Add(user);
            return _users.Find(tempUser => tempUser.Id == user.Id);
        }

        public User UpdateUser(int id, User user)
        {
            var currentUser = GetUserById(id);
            var currentIndex = _users.FindIndex(user1 => user1.Id == id);
            _users[currentIndex] = currentUser;
            return _users[currentIndex];
        }

        public void DeleteUser(int id)
        {
            _users.Remove(GetUserById(id));
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(user1 =>
                user1.Username.Equals(username) && user1.Password.Equals(password));
            
            if (user is null)
                return null;
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("superSecretKeyHere");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;
            return user;
        }
        
        
    }
}