using EADBackend.Models;
using EADBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserManageController : Controller
    {
        private readonly UserService _userService;


        public UserManageController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> getUsers() //api implementation for get all users
        {
            return await _userService.GetUrsersAsync();

        }

        [HttpPost("register")]
        public async Task<IActionResult> registerUser([FromBody] User user)  //api impementation for register user 
        {
            var Newuser =  await _userService.CreateUserAsync(user);
            if (Newuser == null)
            {
                return BadRequest(new { success = false, data = Newuser, msg = "Registration failed" });
            }

            return Ok(new { success = true, data = Newuser, msg = "Registration success" });
        }

  

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteVehicle(string id) // api implementation for delete user
        {

            await _userService.DeleteUserAsync(id);
            return Ok(new { success = true, data = id, msg = "User deleted success" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login) // api implementation for login
        {
            var user = await _userService.validateUser(login.email, login.password);
            if (user == null)
            {
                return NotFound(new { success = false, data = user, token = "", msg = "record not found" });
            }
            var token = _userService.GenerateJSONWebToken(user);
            return Ok(new { success = true, data = user, token = token, msg = "success" });
        }

        [HttpGet("oneuser/{id}")]
        public async Task<User> getaUsers(string id) //api implementation for get one user by id
        {
            return await _userService.GetUrserAsync(id);

        }
    }
}
