using eVoting.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Votes
{
    public interface IVoteService
    {
        Task<List<Vote>> GetVotesByIdsAsync(List<int> ids);

        Task<Vote> GetVoteByIdAsync(int id);

        Task<Vote> GetVotesByMemberIdAsync(int memberId);

        Task<bool> CheckIfMembersAlreadyHaveVotes(int memberId);

        Task<IEnumerable<Vote>> GetMembersVotes();

        Task AddVoteAsync(Vote vote);

        Task<int> SaveChanges();
    }
}
