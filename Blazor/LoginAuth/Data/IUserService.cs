using LoginAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuth.Data
{
    public interface IUserService
    {
        User ValidateUser(string name, string password);
    }
}
