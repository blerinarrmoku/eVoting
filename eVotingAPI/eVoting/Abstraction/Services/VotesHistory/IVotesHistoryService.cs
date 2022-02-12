using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.VotesHistory
{
    public interface IVotesHistoryService
    {
        Task<Models.VotesHistory> GetVotesHistoryByUserId(string userId);

        Task<bool> UserAlreadyVoted(string userId);
    }
}
