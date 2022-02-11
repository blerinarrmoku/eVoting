using System.Collections.Generic;

namespace eVoting.Model.Votes.Queries.GetCountedVotes
{
    public class GetCountedVotesResult
    {
        public List<string> CandidateNames { get; set; } = new();

        public List<int> CandidateVotes { get; set; } = new();
    }
}
