using eVoting.App.Abstraction.Services.Members;
using eVoting.App.Models;
using eVoting.Model.Members.Commands.CreateMember;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Members.Commands.CreateMember
{
    public class CreateMemberHandler : IRequestHandler<CreateMemberCommand, CreateMemberResponse>
    {
        private readonly ILogger<CreateMemberHandler> _logger;
        private readonly IMemberService _memberService;

        public CreateMemberHandler(
            ILogger<CreateMemberHandler> logger,
            IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public async Task<CreateMemberResponse> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Member()
            {
                Name = request.Name,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                ImageUrl = request.ImageUrl,
                InsertDateTime = DateTime.Now,
                IsCandidate = request.IsCandidate,
                IsDeleted = false,
                PartyId = request.PartyId,
                UpdateDateTime = DateTime.Now
            };

            await _memberService.AddMemberAsync(member);
            var inserted = await _memberService.SaveChanges();
            if (inserted < 1)
                return null;

            return new CreateMemberResponse();
        }
    }
}
