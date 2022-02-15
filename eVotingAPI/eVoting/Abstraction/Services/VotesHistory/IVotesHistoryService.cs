using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.VotesHistory
{
    public interface IVotesHistoryService
    {
        Task AddVoteHistoryAsync(eVoting.App.Models.VotesHistory vote);
        Task<bool> UserAlreadyVoted(string userId);
        Task<int> SaveChanges();
    }
}
