using MediatR;

namespace eVoting.Model.Parties.Commands.CreateParty
{
    public class CreatePartyCommand : IRequest<CreatePartyResponse>
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string ImageUrl { get; set; }
    }
}
