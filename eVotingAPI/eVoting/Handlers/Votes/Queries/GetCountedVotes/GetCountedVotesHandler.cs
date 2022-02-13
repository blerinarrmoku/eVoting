using eVoting.App.Abstraction.Services.Votes;
using eVoting.Model.Votes.Queries.GetCountedVotes;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Votes.Queries.GetCountedVotes
{
    public class GetCountedVotesHandler : IRequestHandler<GetCountedVotesQuery, GetCountedVotesResult>
    {
        private readonly ILogger<GetCountedVotesHandler> _logger;
        private readonly IVoteService _voteService;

        public GetCountedVotesHandler(
            ILogger<GetCountedVotesHandler> logger,
            IVoteService voteService)
        {
            _logger = logger;
            _voteService = voteService;
        }

        public async  Task<GetCountedVotesResult> Handle(GetCountedVotesQuery request, CancellationToken cancellationToken)
        {
            var members = await _voteService.GetMembersVotes(request.IsCandidate);

            var model = new GetCountedVotesResult();

            foreach (var item in members)
            {
                model.CandidateNames.Add(item.Member.Name);
                model.CandidateVotes.Add(item.Count);
            }

            return model;
        }
    }
}
