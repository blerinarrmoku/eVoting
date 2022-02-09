using MediatR;
using System.Collections.Generic;

namespace eVoting.Model.Votes.Commands.CreateVote
{
    public class CreateVoteCommand : IRequest<CreateVoteResponse>
    {
        public int CandidateId { get; set; }
        public int PartyId { get; set; }
        public List<int> CheckedCandidates { get; set; }
        public string UserId { get; set; }
    }
}
