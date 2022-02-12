using AutoMapper;

namespace eVoting.App.Framework.Mapping.Cities.Queries
{
    public class GetCitiesMappings : Profile
    {
        public GetCitiesMappings()
        {
            CreateMap<Models.City, Model.Entities.Cities.CityEntity>();
        }
    }
}
