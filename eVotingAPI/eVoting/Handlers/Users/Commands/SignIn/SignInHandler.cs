using eVoting.App.Abstraction.Services.Users;
using eVoting.Model.Users.Commands.SignIn;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Users.Commands.SignIn
{
    public class SignInHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly IUserService _userService;

        public SignInHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.SignIn(request.Email, request.Password);
            if (user != null)
            {
                var model = new SignInResponse();
                model.Email = user.Email;
                model.UserId = user.Id;
                return model;
            } else
            {
                return null;
            }
        }
    }
}
