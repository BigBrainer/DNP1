using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Intf;
using FamilyWebAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace Data.Impl
{
    public class AuthenticationServiceDb : IAuthenticationService
    {
        private readonly FamilyDBContext dbContext;

        public AuthenticationServiceDb(FamilyDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RegisterUserAsync(User user)
        {
            User userToRegister = user;
                User userFromDb = await dbContext.FindAsync<User>(userToRegister.Username);
                if (userFromDb == null)
                {
                    User userToAdd = new User
                    {
                        Username = userToRegister.Username,
                        Password = userToRegister.Password,
                        Department = userToRegister.Department,
                        SecurityLevel = userToRegister.SecurityLevel
                    };

                    await dbContext.User.AddAsync(userToAdd);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Name already taken!");
                }
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
                var validation = dbContext.User.FirstOrDefault(usr => usr.Username.Equals(username) && usr.Password.Equals(password));
                return validation;
        }
    }
}
