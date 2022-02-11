using eVoting.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Cities
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
    }
}
