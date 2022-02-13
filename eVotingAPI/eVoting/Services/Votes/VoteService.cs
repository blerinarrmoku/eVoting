using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> CheckIfMembersAlreadyHaveVotes(int memberId)
        {
            var vote = await GetVotesByMemberIdAsync(memberId);
            if (vote != null)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Vote>> GetMembersVotes(bool IsCandidate)
        {
            return await _context.Votes.Include(t => t.Member).Where(t => t.Member.IsDeleted == false && t.Member.IsCandidate == IsCandidate).OrderByDescending(t => t.Count).ToListAsync();
        }

        public async Task<Vote> GetVoteByIdAsync(int id)
        {
            return await _context.Votes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Vote>> GetVotesByIdsAsync(List<int> ids)
        {
            return await _context.Votes.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<Vote> GetVotesByMemberIdAsync(int memberId)
        {
            return await _context.Votes.Where(x => x.MemberId == memberId).FirstOrDefaultAsync();
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
