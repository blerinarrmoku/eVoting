using AutoMapper;
using eVoting.App.Abstraction.Services.Members;
using eVoting.Model.Members.Queries.GetMembers;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Members.Queries.GetMembers
{
    public class GetMembersHandler : IRequestHandler<GetMembersQuery, GetMembersResult>
    {
        private readonly ILogger<GetMembersHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMemberService _memberService;

        public GetMembersHandler(
            ILogger<GetMembersHandler> logger,
            IMapper mapper,
            IMemberService memberService)
        {
            _logger = logger;
            _mapper = mapper;
            _memberService = memberService;
        }

        public async Task<GetMembersResult> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _memberService.GetMembersAsync();
            var result = new GetMembersResult();
            foreach (var member in members)
            {
                var mapped = _mapper.Map<Model.Entities.Members.MemberEntity>(member);
                result.Members.Add(mapped);
            }

            return result;
        }
    }
}
