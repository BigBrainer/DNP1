using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Authorization
{
    public interface IAuthenticationService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task RegisterUserAsync(User user);
    }
}
