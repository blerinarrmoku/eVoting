using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Users
{
    public interface IUserService
    {
        Task<IdentityUser> SignIn(string email, string password);
    }
}
