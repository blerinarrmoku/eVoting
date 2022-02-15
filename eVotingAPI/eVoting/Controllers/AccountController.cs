using eVoting.App.ViewModels;
using eVoting.Model.Response;
using eVoting.Model.Users.Commands.SignIn;
using eVoting.Model.Users.Queries.UserVoted;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager, 
                                 IMediator mediator) : base(mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("signin")]
        public async Task<ActionResult<ResponseModel<SignInResponse>>> SignIn(SignInCommand signInCommand)
        {
            var response = new ResponseModel<SignInResponse>();
            if (signInCommand.Email == null || signInCommand.Password == null)
            {
                return BadRequest(response.AddMessage("Parameters are not valid!").BadRequest());
            }

            var responseContent = await Mediator.Send(signInCommand);
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error happened while signing in!").BadRequest());

            return Ok(response.AddMessage("Sign in successfully").Ok(responseContent));
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

        [HttpGet("userVoted")]
        public async Task<ActionResult<ResponseModel<UserVotedResult>>> UserVoted(string userId)
        {
            var response = new ResponseModel<UserVotedResult>();
            if (userId == null)
            {
                return BadRequest(response.AddMessage("Parameters are not valid!").BadRequest());
            }

            var responseContent = await Mediator.Send(new UserVotedQuery { UserId = userId });
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error happened!").BadRequest());

            return Ok(response.AddMessage("User Founded").Ok(responseContent));
        }

    }
}
