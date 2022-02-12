using eVoting.Model.Entities.Parties;
using System.Collections.Generic;

namespace eVoting.Model.Parties.Queries.GetParties
{
    public class GetPartiesResult
    {
        public List<PartyEntity> Parties { get; set; } = new();
    }
}
