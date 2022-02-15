using eVoting.App.Abstraction.Services.VotesHistory;
using eVoting.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Services.VotesHistory
{
    public class VotesHistoryService : IVotesHistoryService
    {
        private readonly ILogger<VotesHistoryService> _logger;
        private readonly EVotingContext _context;

        public VotesHistoryService(
            ILogger<VotesHistoryService> logger,
            EVotingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task AddVoteHistoryAsync(Models.VotesHistory vote)
        {
            await _context.VotesHistories.AddAsync(vote);
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<bool> UserAlreadyVoted(string userId)
        {
            var voteHistory = await _context.VotesHistories.FirstOrDefaultAsync(x => x.UserId == userId);
            if (voteHistory != null)
                return true;

            return false;
        }
    }
}
