using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Model.Users.Queries.UserVoted
{
    public class UserVotedQuery : IRequest<UserVotedResult>
    {
        public string UserId { get; set; }
    }
}
