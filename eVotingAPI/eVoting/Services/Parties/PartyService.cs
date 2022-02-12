using eVoting.App.Abstraction.Services.Parties;
using eVoting.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Services.Parties
{
    public class PartyService : IPartyService
    {
        private readonly ILogger<PartyService> _logger;
        private readonly EVotingContext _context;


        public PartyService(
            ILogger<PartyService> logger,
            EVotingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<Party>> GetPartiesAsync()
        {
            return await _context.Parties.Where(x => x.IsDeleted == false).ToListAsync();
        }
    }
}
