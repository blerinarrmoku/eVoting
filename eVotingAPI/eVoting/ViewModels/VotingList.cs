using eVoting.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.ViewModels
{
    public class VotingList
    {
        public IEnumerable<Member> Candidates { get; set; }
        public IEnumerable<Party> Parties { get; set; }
    }
}
