using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Model.Users.Commands.SignIn
{
    public class SignInResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}
