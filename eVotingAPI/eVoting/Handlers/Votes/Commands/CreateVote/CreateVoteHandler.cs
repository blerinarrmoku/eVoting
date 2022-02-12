using eVoting.App.Abstraction.Services.Members;
using eVoting.App.Abstraction.Services.Votes;
using eVoting.App.Abstraction.Services.VotesHistory;
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
        private readonly IVotesHistoryService _votesHistoryService;

        public CreateVoteHandler(
            ILogger<CreateVoteHandler> logger,
            IVoteService voteService,
            IMemberService memberService,
            IVotesHistoryService votesHistoryService)
        {
            _logger = logger;
            _voteService = voteService;
            _memberService = memberService;
            _votesHistoryService = votesHistoryService;
        }

        public async Task<CreateVoteResponse> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
        {
            var userAlreadyVoted = await _votesHistoryService.UserAlreadyVoted(request.UserId);
            if (!userAlreadyVoted)
            {
                // Pjesa per asambleist
                var candidates = await _memberService.GetMembersByIdsAsync(request.CheckedCandidates);

                foreach (var candidate in candidates)
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
                            InsertDateTime = DateTime.Now,
                            UpdateDateTime = DateTime.Now,
                            MemberId = candidate.Id,
                            Count = 1
                        };
                        await _voteService.AddVoteAsync(vote);
                    }
                }
                // Pjesa per Kryetar
                var alreadyVoted = await _voteService.CheckIfMembersAlreadyHaveVotes(request.CandidateId);
                if (alreadyVoted)
                {
                    var actualVotesForCandidate = await _voteService.GetVotesByMemberIdAsync(request.CandidateId);
                    actualVotesForCandidate.Count++;
                }
                else
                {
                    var mainCandidateVote = new Vote()
                    {
                        InsertDateTime = DateTime.Now,
                        UpdateDateTime = DateTime.Now,
                        MemberId = request.CandidateId,
                        Count = 1,
                    };
                    await _voteService.AddVoteAsync(mainCandidateVote);
                }
                await _voteService.SaveChanges();
                return new CreateVoteResponse();
            }
            else
            {
                return null;
            }
        }
    }
}
