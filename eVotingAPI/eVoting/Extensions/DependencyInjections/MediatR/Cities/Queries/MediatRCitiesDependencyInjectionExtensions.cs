using eVoting.App.Handlers.Cities.Queries.GetCities;
using eVoting.Model.Cities.Queries.GetCities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Cities.Queries
{
    public static class MediatRCitiesDependencyInjectionExtensions
    {
        public static void AddCitiesQuery(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetCitiesQuery, GetCitiesResult>, GetCitiesHandler>();
        }
    }
}
