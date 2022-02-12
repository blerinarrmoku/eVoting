using eVoting.App.Handlers.Users.Commands.SignIn;
using eVoting.Model.Users.Commands.SignIn;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Users.Commands
{
    public static class MediatRUsersDependencyInjectionExtensions
    {
        public static void AddUsersCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<SignInCommand, SignInResponse>, SignInHandler>();
        }
    }
}
