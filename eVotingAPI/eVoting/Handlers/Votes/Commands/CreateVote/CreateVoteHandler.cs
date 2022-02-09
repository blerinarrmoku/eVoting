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

        public CreateVoteHandler(
            ILogger<CreateVoteHandler> logger,
            IVoteService voteService)
        {
            _logger = logger;
            _voteService = voteService;
        }

        public async Task<CreateVoteResponse> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
        {
            var vote = new Vote()
            {
                Id = new(),
                InsertDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                MemberId = request.CandidateId,
                Count = 1
            };

            await _voteService.AddVoteAsync(vote);
            await _voteService.SaveChanges();

            return new CreateVoteResponse();
        }
    }
}
