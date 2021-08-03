using System.Collections.Generic;

namespace dotnet_jwt_authentication.Models
{
    public class User {
        public int Id { get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string Token {get; set;}
    }
}