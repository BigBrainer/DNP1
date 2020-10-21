﻿using Assignment_1.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment_1.Data.Impl
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jSRuntime;
        private readonly IAuthenticationService authenticationService;

        private User cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jSRuntime, IAuthenticationService authenticationService)
        {
            this.jSRuntime = jSRuntime;
            this.authenticationService = authenticationService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if(cachedUser == null)
            {
                string userAsJson = await jSRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    cachedUser = JsonSerializer.Deserialize<User>(userAsJson);
                    identity = SetupClaimsForUser(cachedUser);
                }    
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        public void ValidateLogin(string username, string password)
        {
            Console.WriteLine("Validating login info");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter a username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter a password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                User user = authenticationService.ValidateUser(username, password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                jSRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            }
            catch(Exception e)
            {
                throw e;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void Register(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                authenticationService.RegisterUser(user);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                jSRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            }
            catch(Exception e)
            {
                throw e;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim("Department", user.Department));
            claims.Add(new Claim("Level", user.SecurityLevel.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }

        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jSRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
