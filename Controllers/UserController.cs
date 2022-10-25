using EADBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser applicationUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email

                };
                IdentityResult result = await _userManager.CreateAsync(applicationUser, user.Password);
                if (result.Succeeded)
                {
                    ViewBag.Message = "User Created Successfully";
                    return Ok();
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return BadRequest();
        }

        [HttpPost("/postrole")]
        public async Task<IActionResult> CreateRole([FromBody] UserRole userRole) {

            if (ModelState.IsValid) {
                IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = userRole.RoleName });

                if (result.Succeeded)
                {
                    ViewBag.Message = "User Created Successfully";
                    return Ok();
                }

                else {

                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return BadRequest();
        }




    }
}
