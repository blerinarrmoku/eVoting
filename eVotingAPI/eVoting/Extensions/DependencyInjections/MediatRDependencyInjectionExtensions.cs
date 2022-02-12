using eVoting.App.Extensions.DependencyInjections.MediatR.Votes;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using eVoting.App.Extensions.DependencyInjections.MediatR.Cities.Queries;
using eVoting.App.Extensions.DependencyInjections.MediatR.Votes.Queries;
using eVoting.App.Extensions.DependencyInjections.MediatR.Users.Commands;
using eVoting.App.Extensions.DependencyInjections.MediatR.Members.Commands;

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

        }
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddCitiesQuery();
            services.GetVotesQueryHandlers();
        }
    }
}
