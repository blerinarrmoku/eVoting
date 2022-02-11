using AutoMapper;

namespace eVoting.App.Framework.Mapping.Cities.Query
{
    public class GetCitiesMappings : Profile
    {
        public GetCitiesMappings()
        {
            CreateMap<Models.City, Model.Entities.Cities.CityEntity>();
        }
    }
}
