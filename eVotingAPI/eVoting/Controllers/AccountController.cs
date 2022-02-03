using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            try
            {
                var user = new IdentityUser
                {

                    UserName = "kukadion1@gmail.com",
                    Email = "kukadion1@gmail.com",
                    PhoneNumber = null
                };

                var userExist = await _userManager.FindByEmailAsync(user.Email);

                if (userExist != null)
                { 
                    return NotFound();
                }

                var result = await _userManager.CreateAsync(user, "123456");

                if (!result.Succeeded)
                {
                    return NotFound();
                }

                if (result.Succeeded)
                {
                    /*var role = await roleManager.FindByIdAsync("1");
                    await userManager.AddToRoleAsync(user, role.Name);*/
                    return Ok();
                }

                return Ok();
            }

            catch (Exception ex)
            {
                return Ok();
            }
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn()
        {
            var result = await _signInManager.PasswordSignInAsync("kukadion1@gmail.com", "123456", true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
            }
            return Ok();
        }
        
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }

    }
}
