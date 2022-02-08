using eVoting.App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eVoting.App.ViewModels.ReturnObject;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn(SignInViewModel model)
        {
            var returnObject = new ReturnObject();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                returnObject.Message = "Successfully Signed In";
                returnObject.Type = "success";
                return Ok(returnObject);
            }
            returnObject.Message = "Something went wrong";
            returnObject.Type = "error";
            return Ok(returnObject);
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(SignUpViewModel model)
        {
            var returnObject = new ReturnObject();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser
                    {

                        UserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = null
                    };

                    var userExist = await _userManager.FindByEmailAsync(user.Email);

                    if (userExist != null)
                    {
                        returnObject.Message = "Email is taken";
                        returnObject.Type = "error";
                        return Ok(returnObject);
                    }

                    if (model.Password != model.ConfirmPassword)
                    {
                        returnObject.Message = "Password not matching";
                        returnObject.Type = "error";
                        return Ok(returnObject);
                    }

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (!result.Succeeded)
                    {
                        returnObject.Message = "Password not valid";
                        returnObject.Type = "error";
                        return Ok(returnObject);
                    }

                    if (result.Succeeded)
                    {
                        //var role = await roleManager.FindByIdAsync("1");
                        //await userManager.AddToRoleAsync(user, role.Name);
                        returnObject.Message = "Successfully Signed Up";
                        returnObject.Type = "success";
                        return Ok(returnObject);
                    }

                }
                returnObject.Message = "Something went wrong";
                returnObject.Type = "error";
                return Ok(returnObject);
            }

            catch (Exception ex)
            {
                returnObject.Message = ex.Message;
                returnObject.Type = "error";
                return Ok(returnObject);
            }
        }


    }
}
