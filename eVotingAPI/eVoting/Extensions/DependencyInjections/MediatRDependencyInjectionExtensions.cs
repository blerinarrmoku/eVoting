using eVoting.App.Extensions.DependencyInjections.MediatR.Votes;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using eVoting.App.Extensions.DependencyInjections.MediatR.Cities.Queries;

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
        }
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddCitiesQuery();
        }
    }
}
