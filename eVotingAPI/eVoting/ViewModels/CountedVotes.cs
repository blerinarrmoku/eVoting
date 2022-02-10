using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.ViewModels
{
    public class CountedVotes
    {
        public List<string> Candidates { get; set; }
        public List<int> Votes { get; set; }
    }
}
