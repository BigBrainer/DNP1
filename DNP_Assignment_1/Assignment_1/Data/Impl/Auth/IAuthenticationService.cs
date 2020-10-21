using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Data
{
    public interface IAuthenticationService
    {
        User ValidateUser(string username, string password);
        User RegisterUser(User user);

        void StoreObject(List<User> users);
        List<User> ReadObject();
    }
}
