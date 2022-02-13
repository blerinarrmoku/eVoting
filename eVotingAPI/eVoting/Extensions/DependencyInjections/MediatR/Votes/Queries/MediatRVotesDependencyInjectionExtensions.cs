using eVoting.App.Handlers.Votes.Queries.GetCountedVotes;
using eVoting.App.Handlers.Votes.Queries.GetValidVotes;
using eVoting.Model.Votes.Queries.GetCountedVotes;
using eVoting.Model.Votes.Queries.GetValidVotes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Votes.Queries
{
    public static class MediatRVotesDependencyInjectionExtensions
    {
        public static void GetVotesQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetCountedVotesQuery, GetCountedVotesResult>, GetCountedVotesHandler>();
        }
        public static void GetValidVotesQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetValidVotesQuery, GetValidVotesResult>, GetValidVotesHandler>();
        }
    }
}
