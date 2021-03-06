using eVoting.App.Abstraction.Services.Cities;
using eVoting.App.Abstraction.Services.Contacts;
using eVoting.App.Abstraction.Services.Members;
using eVoting.App.Abstraction.Services.Parties;
using eVoting.App.Abstraction.Services.Users;
using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Abstraction.Services.VotesHistory;
using eVoting.App.Services.Cities;
using eVoting.App.Services.Contacts;
using eVoting.App.Services.Members;
using eVoting.App.Services.Parties;
using eVoting.App.Services.Users;
using eVoting.App.Services.Votes;
using eVoting.App.Services.VotesHistory;
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
            services.AddTransient<IVotesHistoryService, VotesHistoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPartyService, PartyService>();
            services.AddTransient<IContactService, ContactService>();
        }
    }
}
