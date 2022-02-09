using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Services.Votes;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections
{
    public static class ServicesDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IVoteService, VoteService>();
        }
    }
}
