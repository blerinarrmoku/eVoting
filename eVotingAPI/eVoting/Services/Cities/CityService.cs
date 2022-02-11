using eVoting.App.Abstraction.Services.Cities;
using eVoting.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVoting.App.Services.Cities
{
    public class CityService : ICityService
    {
        private readonly ILogger<CityService> _logger;
        private readonly EVotingContext _context;


        public CityService(
            ILogger<CityService> logger,
            EVotingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
