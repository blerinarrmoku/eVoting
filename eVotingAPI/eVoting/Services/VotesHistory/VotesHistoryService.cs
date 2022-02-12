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

        public async Task<Models.VotesHistory> GetVotesHistoryByUserId(string userId)
        {
            return await _context.VotesHistories.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<bool> UserAlreadyVoted(string userId)
        {
            if (GetVotesHistoryByUserId(userId) != null)
                return true;

            return false;
        }
    }
}
