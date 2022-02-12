using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Model.Members.Queries.DeleteMember
{
    public class DeleteMemberQuery : IRequest<DeleteMemberResult>
    {
        public int Id { get; set; }
    }
}
