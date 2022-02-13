using AutoMapper;
using eVoting.App.Abstraction.Services.Members;
using eVoting.Model.Members.Queries.DeleteMember;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Members.Queries.DeleteMember
{
    public class DeleteMemberHandler : IRequestHandler<DeleteMemberQuery, DeleteMemberResult>
    {
        private readonly ILogger<DeleteMemberHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMemberService _memberService;

        public DeleteMemberHandler(
            ILogger<DeleteMemberHandler> logger,
            IMapper mapper,
            IMemberService memberService)
        {
            _logger = logger;
            _mapper = mapper;
            _memberService = memberService;
        }

        public async Task<DeleteMemberResult> Handle(DeleteMemberQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberService.GetMemberByIdAsync(request.Id);
            var deleted = await _memberService.DeleteMemberAsync(request.Id);
            await _memberService.SaveChanges();
            var mapped = _mapper.Map<Model.Entities.Members.MemberEntity>(member);

            if (deleted)
            {
                var model = new DeleteMemberResult();
                model.Member = mapped;
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
