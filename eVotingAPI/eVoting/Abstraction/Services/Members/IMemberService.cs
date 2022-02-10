using eVoting.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVoting.App.Abstraction.Services.Members
{
    public interface IMemberService
    {
        Task AddMemberAsync(Member vote);

        Task UpdateMemberAsync(Member member);

        Task<Member> GetMemberByIdAsync(int id);

        Task<List<Member>> GetMembersAsync();

        Task<List<Member>> GetMembersByIdsAsync(List<int> ids);

        Task<bool> DeleteMemberAsync(int id);

        Task<int> SaveChanges();
    }
}
