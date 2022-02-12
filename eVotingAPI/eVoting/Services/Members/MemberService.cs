using eVoting.App.Abstraction.Services.Members;
using eVoting.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Services.Members
{
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private readonly EVotingContext _context;


        public MemberService(
            ILogger<MemberService> logger,
            EVotingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task AddMemberAsync(Member member)
        {
            await _context.Members.AddAsync(member);
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            var memberToDelete = await GetMemberByIdAsync(id);
            if (memberToDelete != null)
            {
                _context.Remove(memberToDelete);
                return true;
            }

            return false;
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<List<Models.Member>> GetMembersAsync()
        {
            return await _context.Members.Include(t => t.Party).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public Task<List<Member>> GetMembersByIdsAsync(List<int> ids)
        {
            return _context.Members.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(Member member)
        {
            _context.Members.Update(member);
        }
    }
}
