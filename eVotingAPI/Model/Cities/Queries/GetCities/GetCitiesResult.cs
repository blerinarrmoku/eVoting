using eVoting.Model.Entities.Cities;
using System.Collections.Generic;

namespace eVoting.Model.Cities.Queries.GetCities
{
    public class GetCitiesResult
    {
        public List<CityEntity> Cities { get; set; } = new();
    }
}
