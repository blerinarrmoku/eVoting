using AutoMapper;
using eVoting.App.Abstraction.Services.Parties;
using eVoting.Model.Parties.Queries.GetParties;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Parties.Queries.GetParties
{
    public class GetPartiesHandler : IRequestHandler<GetPartiesQuery, GetPartiesResult>
    {
        private readonly ILogger<GetPartiesHandler> _logger;
        private readonly IPartyService _partyService;
        private readonly IMapper _mapper;

        public GetPartiesHandler(
            ILogger<GetPartiesHandler> logger,
            IPartyService partyService,
            IMapper mapper)
        {
            _logger = logger;
            _partyService = partyService;
            _mapper = mapper;
        }
        public async Task<GetPartiesResult> Handle(GetPartiesQuery request, CancellationToken cancellationToken)
        {
            var parties = await _partyService.GetPartiesAsync();
            var result = new GetPartiesResult();
            foreach (var party in parties)
            {
                var mapped = _mapper.Map<Model.Entities.Parties.PartyEntity>(party);
                result.Parties.Add(mapped);
            }

            return result;
        }
    }
}
