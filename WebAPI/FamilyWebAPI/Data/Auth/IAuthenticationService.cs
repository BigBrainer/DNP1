using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Intf
{
    public interface IAuthenticationService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task<User> RegisterUserAsync(User user);
       void StoreObject(List<User> users);
        List<User> ReadObject();
    }
}
