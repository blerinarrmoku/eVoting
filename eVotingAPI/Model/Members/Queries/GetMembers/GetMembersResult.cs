using eVoting.Model.Entities.Members;
using System.Collections.Generic;

namespace eVoting.Model.Members.Queries.GetMembers
{
    public class GetMembersResult
    {
        public List<MemberEntity> Members { get; set; } = new();
    }
}
