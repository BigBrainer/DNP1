﻿using Assignment_2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment_2.Data.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<User> Users { get; set; }


        public AuthenticationService()
        {
            Users = ReadObject();
        }
        public User ValidateUser(string username, string password)
        {
            User first = ReadObject().FirstOrDefault(user => user.Username.Equals(username));
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

        public User RegisterUser(User user)
        {
            User userWithSameUsername = ReadObject().FirstOrDefault(compare => user.Username.Equals(compare.Username));
            if (userWithSameUsername != null)
            {
                throw new Exception("Username not available");
            }
            if (user.Department.Equals("Administrator", StringComparison.InvariantCultureIgnoreCase))
            {
                user.SecurityLevel = 2;
            }
            else
            {
                user.SecurityLevel = 1;
            }
            Users.Add(user);
            StoreObject(Users);
            return user;
        }

        public void StoreObject(List<User> users)
        {
            File.WriteAllText("./bin/Debug/netcoreapp3.1/Users.json", JsonSerializer.Serialize(Users));
        }

        public List<User> ReadObject()
        {
            return JsonSerializer.Deserialize<List<User>>(File.ReadAllText("./bin/Debug/netcoreapp3.1/Users.json"));
        }

    }
}