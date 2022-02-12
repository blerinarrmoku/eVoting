using AutoMapper;
using eVoting.App.Framework.Mapping.Cities.Queries;
using eVoting.App.Framework.Mapping.Members.Queries;
using eVoting.App.Framework.Mapping.Parties.Queries;
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
                cfg.AddProfile<GetMembersMappings>();
                cfg.AddProfile<GetPartiesMappings>();
                #endregion
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
