using eVoting.App.Abstraction.Services.Votes;
using eVoting.Model.Votes.Queries.GetValidVotes;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Votes.Queries.GetValidVotes
{
    public class GetValidVotesHandler : IRequestHandler<GetValidVotesQuery, GetValidVotesResult>
    {
        private readonly ILogger<GetValidVotesHandler> _logger;
        private readonly IVoteService _voteService;

        public GetValidVotesHandler(
            ILogger<GetValidVotesHandler> logger,
            IVoteService voteService)
        {
            _logger = logger;
            _voteService = voteService;
        }

        public async Task<GetValidVotesResult> Handle(GetValidVotesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetValidVotesResult();
            var members = await _voteService.GetMembersVotes(true);

            Random rnd = new Random(DateTime.UtcNow.Millisecond);
            IBlock genesis = new Block(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 });
            byte[] difficulty = new byte[] { 0x00, 0x00 };
            string stringu = "";
            BlockChain chain = new BlockChain(difficulty, genesis);
            foreach (var member in members)
            {
                var data = Enumerable.Range(0, 2256).Select(p => (byte)rnd.Next());
                chain.Add(new Block(data.ToArray()));
                stringu += chain.LastOrDefault()?.ToString();

                stringu += $"Chain is valid: { chain.IsValid()}";
            }
            response.Text = stringu;
            return response;
        }
    }
}
