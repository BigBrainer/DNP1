using Assignment_1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment_1.Authorization
{
    public class AuthenticationService : IAuthenticationService
    { 
        readonly private string uri = "http://localhost:5003/api/User";
        readonly private HttpClient client;

        public AuthenticationService()
        {
            client = new HttpClient();
        }

    public async Task<User> ValidateUserAsync(string username, string password)
        {
            string passwordSerialized = JsonSerializer.Serialize(password);
            StringContent content = new StringContent(
                passwordSerialized,
                Encoding.UTF8,
                "application/json"
            );
           HttpResponseMessage response = await client.PostAsync($"{uri}/login?username={username}", content);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
            throw new Exception("User not found");
        }

        public async Task RegisterUserAsync(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "application/json"
                );
            await client.PostAsync(uri, content);
        }
    }
}
