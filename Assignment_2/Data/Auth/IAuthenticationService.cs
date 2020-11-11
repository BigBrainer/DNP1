using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Data
{
    public interface IAuthenticationService
    {
        User ValidateUser(string username, string password);
        User RegisterUser(User user);

        void StoreObject(List<User> users);
        List<User> ReadObject();
    }
}
