using eVoting.App.Abstraction.Services.Members;
using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Models;
using eVoting.Model.Votes.Commands.CreateVote;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Votes.Commands.CreateVote
{
    public class CreateVoteHandler : IRequestHandler<CreateVoteCommand, CreateVoteResponse>
    {
        private readonly ILogger<CreateVoteHandler> _logger;
        private readonly IVoteService _voteService;
        private readonly IMemberService _memberService;

        public CreateVoteHandler(
            ILogger<CreateVoteHandler> logger,
            IVoteService voteService,
            IMemberService memberService)
        {
            _logger = logger;
            _voteService = voteService;
            _memberService = memberService;
        }

        public async Task<CreateVoteResponse> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
        {
            var candidates = await _memberService.GetMembersByIdsAsync(request.CheckedCandidates);

            foreach(var candidate in candidates)
            {
                var alreadyHaveVotes = await _voteService.CheckIfMembersAlreadyHaveVotes(candidate.Id);
                
                if (alreadyHaveVotes)
                {
                    var actualVotesForCandidate = await _voteService.GetVotesByMemberIdAsync(candidate.Id);
                    actualVotesForCandidate.Count++;
                }
                else
                {
                    var vote = new Vote()
                    {
                        Id = new(),
                        InsertDateTime = DateTime.Now,
                        UpdateDateTime = DateTime.Now,
                        MemberId = candidate.Id,
                        Count = 1
                    };
                    await _voteService.AddVoteAsync(vote);
                }
            }
            await _voteService.SaveChanges();
            return new CreateVoteResponse();
        }
    }
}
