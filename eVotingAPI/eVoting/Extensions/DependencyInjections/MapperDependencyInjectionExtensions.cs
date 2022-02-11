using AutoMapper;
using eVoting.App.Framework.Mapping.Cities.Query;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections
{
    public static class MapperDependencyInjectionExtensions
    {
        public static void AddMappingWithProfiles(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                #region queries
                cfg.AddProfile<GetCitiesMappings>();
                #endregion
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
