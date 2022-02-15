using AutoMapper;
using eVoting.App.Abstraction.Services.Users;
using eVoting.App.Abstraction.Services.VotesHistory;
using eVoting.Model.Users.Queries.UserVoted;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Users.Queries.UserVoted
{
    public class UserVotedHandler : IRequestHandler<UserVotedQuery, UserVotedResult>
    {
        private readonly ILogger<UserVotedHandler> _logger;
        private readonly IVotesHistoryService _votesHistoryService;
        private readonly IMapper _mapper;

        public UserVotedHandler(
            ILogger<UserVotedHandler> logger,
            IVotesHistoryService votesHistoryService,
            IMapper mapper)
        {
            _logger = logger;
            _votesHistoryService = votesHistoryService;
            _mapper = mapper;
        }
        public async Task<UserVotedResult> Handle(UserVotedQuery request, CancellationToken cancellationToken)
        {
            var result =  await _votesHistoryService.UserAlreadyVoted(request.UserId);

            return new UserVotedResult { UserVoted = result };
        }
    }
}
