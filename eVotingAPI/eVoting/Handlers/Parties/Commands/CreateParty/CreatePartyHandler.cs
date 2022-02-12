using eVoting.App.Abstraction.Services.Parties;
using eVoting.App.Models;
using eVoting.Model.Parties.Commands.CreateParty;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Parties.Commands.CreateParty
{
    public class CreatePartyHandler : IRequestHandler<CreatePartyCommand, CreatePartyResponse>
    {
        private readonly ILogger<CreatePartyHandler> _logger;
        private readonly IPartyService _partyService;

        public CreatePartyHandler(
            ILogger<CreatePartyHandler> logger,
            IPartyService partyService)
        {
            _logger = logger;
            _partyService = partyService;
        }
        public async Task<CreatePartyResponse> Handle(CreatePartyCommand request, CancellationToken cancellationToken)
        {
            var party = new Party()
            {
                Name = request.Name,
                Abbreviation = request.Abbreviation,
                CityId = request.CityId,
                ImageUrl = request.ImageUrl,
                InsertDateTime = DateTime.Now,
                IsDeleted = false,
                UpdateDateTime = DateTime.Now,
            };

            await _partyService.AddPartyAsync(party);
            var inserted = await _partyService.SaveChanges();
            if (inserted < 1)
                return null;

            return new CreatePartyResponse();
        }
    }
}
