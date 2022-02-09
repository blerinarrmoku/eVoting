using eVoting.App.Models;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Votes
{
    public interface IVoteService
    {
        Task AddVoteAsync(Vote vote);

        Task<int> SaveChanges();
    }
}
