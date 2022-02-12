using eVoting.App.Handlers.Parties.Queries.GetParties;
using eVoting.Model.Parties.Queries.GetParties;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Parties.Queries
{
    public static class MediatRPartiesDependencyInjectionExtensions
    {
        public static void GetPartiesQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetPartiesQuery, GetPartiesResult>, GetPartiesHandler>();
        }
    }
}
