using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Model.Votes.Queries.GetCountedVotes
{
    public class GetCountedVotesQuery : IRequest<GetCountedVotesResult>
    {
        public bool IsCandidate { get; set; }
    }
}
