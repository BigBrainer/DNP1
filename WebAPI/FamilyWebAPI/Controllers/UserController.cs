using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Data.Impl;
using Data.Intf;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using IAuthenticationService = Data.Intf.IAuthenticationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAuthenticationService service;
        public UserController(IAuthenticationService service)
        {
            this.service = service;
        }

        // POST api/<UserController>
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="user">User being registered</param>
        /// <returns>User for the client</returns>
        [HttpPost]
        public async Task<ActionResult<User>> RegisterAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await service.RegisterUserAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Log in as a user
        /// </summary>
        /// <param name="username">Username for the user</param>
        /// <param name="password">Password for the user</param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> LoginAsync([FromQuery] string username, [FromBody] string password)
        {
            try
            {
                User user = await service.ValidateUserAsync(username, password);
                return Ok(user);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
