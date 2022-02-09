using eVoting.App.Handlers.Votes.Commands.CreateVote;
using eVoting.Model.Votes.Commands.CreateVote;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Votes
{
    public static class MediatRVotesDependencyInjectionExtensions
    {
        public static void AddVoteCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateVoteCommand, CreateVoteResponse>, CreateVoteHandler>();
        }
    }
}
