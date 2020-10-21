using LoginAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LoginAuth.Data.Implementation
{
    public class InMemoryUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[] {
            new User
            {
                Username = "Jane",
                Password = "1234",
                Role = "Police",
                SecurityLevel = 1
            },
            new User
            {
                Username = "John",
                Password = "1234",
                Role = "Child services",
                SecurityLevel = 2
            },
            }.ToList();
        }
        public User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }
            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }

        public void RegisterUser(string username, string password, int birthYear)
        {

        }
    }
}
