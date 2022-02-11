using eVoting.App.Abstraction.Services.Cities;
using eVoting.App.Abstraction.Services.Members;
using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Services.Cities;
using eVoting.App.Services.Members;
using eVoting.App.Services.Votes;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IVoteService, VoteService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<ICityService, CityService>();
        }
    }
}
