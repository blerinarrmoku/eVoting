using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.Model.Parties.Queries.DeleteParty
{
    public class DeletePartyQuery : IRequest<DeletePartyResult>
    {
        public int Id { get; set; }
    }
}
