using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.ViewModels
{
    public class VotingViewModel
    {
        public int CandidateId { get; set; }
        public int PartyId { get; set; }
        public List<int> CheckedCandidates { get; set; }
    }
}
