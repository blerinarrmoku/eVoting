using AutoMapper;
using eVoting.App.Abstraction.Services.Parties;
using eVoting.Model.Parties.Queries.DeleteParty;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Parties.Queries.DeleteParty
{
    public class DeletePartyHandler : IRequestHandler<DeletePartyQuery, DeletePartyResult>
    {
        private readonly ILogger<DeletePartyHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPartyService _partiesService;

        public DeletePartyHandler(
            ILogger<DeletePartyHandler> logger,
            IMapper mapper,
            IPartyService partiesService)
        {
            _logger = logger;
            _mapper = mapper;
            _partiesService = partiesService;
        }

        public async Task<DeletePartyResult> Handle(DeletePartyQuery request, CancellationToken cancellationToken)
        {
            var deletedParty = await _partiesService.DeleteParty(request.Id);
            await _partiesService.SaveChanges();
            var mapped = _mapper.Map<Model.Entities.Parties.PartyEntity>(deletedParty);
            var model = new DeletePartyResult();
            model.Party = mapped;
            return model;
        }
    }
}
