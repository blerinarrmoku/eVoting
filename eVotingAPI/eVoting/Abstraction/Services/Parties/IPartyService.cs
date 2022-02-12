using eVoting.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Parties
{
    public interface IPartyService
    {
        Task<List<Party>> GetMembersAsync();
    }
}
