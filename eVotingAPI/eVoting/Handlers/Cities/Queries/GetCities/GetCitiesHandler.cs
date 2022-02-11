using AutoMapper;
using eVoting.App.Abstraction.Services.Cities;
using eVoting.Model.Cities.Queries.GetCities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Cities.Queries.GetCities
{
    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, GetCitiesResult>
    {
        private readonly ILogger<GetCitiesHandler> _logger;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public GetCitiesHandler(
            ILogger<GetCitiesHandler> logger,
            ICityService cityService,
            IMapper mapper)
        {
            _logger = logger;
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<GetCitiesResult> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var allCities = await _cityService.GetAllCities();
            GetCitiesResult result = new GetCitiesResult();
            foreach (var city in allCities)
            {
                var mapped = _mapper.Map<Model.Entities.Cities.CityEntity>(city);
                result.Cities.Add(mapped);
            }

            return result;
        }
    }
}
