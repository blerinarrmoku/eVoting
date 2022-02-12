using eVoting.App.Abstraction.Services.Parties;
using eVoting.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Services.Parties
{
    public class PartyService : IPartyService
    {
        public Task<List<Party>> GetMembersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
