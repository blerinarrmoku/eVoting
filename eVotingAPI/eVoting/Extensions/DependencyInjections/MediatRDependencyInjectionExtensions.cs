using eVoting.App.Extensions.DependencyInjections.MediatR.Votes;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using eVoting.App.Extensions.DependencyInjections.MediatR.Cities.Queries;
using eVoting.App.Extensions.DependencyInjections.MediatR.Votes.Queries;
using eVoting.App.Extensions.DependencyInjections.MediatR.Users.Commands;
using eVoting.App.Extensions.DependencyInjections.MediatR.Members.Commands;
using eVoting.App.Extensions.DependencyInjections.MediatR.Members.Queries;
using eVoting.App.Extensions.DependencyInjections.MediatR.Parties.Queries;
using eVoting.App.Extensions.DependencyInjections.MediatR.Parties.Commands;
using eVoting.App.Extensions.DependencyInjections.MediatR.Contacts.Commands;
using eVoting.App.Extensions.DependencyInjections.MediatR.Users.Queries;

namespace eVoting.App.Extensions.DependencyInjections
{
    public static class MediatRDependencyInjectionExtensions
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
        }

        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddVoteCommandHandlers();
            services.AddUsersCommandHandlers();
            services.AddMembersCommandHandlers();
            services.AddPartyCommandHandlers();
            services.AddContactsQuery();

        }
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.GetCitiesQuery();
            services.GetVotesQueryHandlers();
            services.GetMembersQueryHandlers();
            services.GetPartiesQueryHandlers();
            services.DeleteMemberQueryHandlers();
            services.DeletePartyQueryHandlers();
            services.GetValidVotesQueryHandlers();
            services.UserVotedQueryHandlers();
        }
    }
}
