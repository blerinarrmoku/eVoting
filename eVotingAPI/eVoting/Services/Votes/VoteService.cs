using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace eVoting.App.Services.Votes
{
    public class VoteService : IVoteService
    {
        private readonly ILogger<VoteService> _logger;
        private readonly EVotingContext _context;


        public VoteService(
            ILogger<VoteService> logger,
            EVotingContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task AddVoteAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
