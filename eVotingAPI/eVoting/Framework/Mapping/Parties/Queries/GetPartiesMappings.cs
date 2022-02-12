using AutoMapper;

namespace eVoting.App.Framework.Mapping.Parties.Queries
{
    public class GetPartiesMappings : Profile
    {
        public GetPartiesMappings()
        {
            CreateMap<Models.Party, Model.Entities.Parties.PartyEntity>();
        }
    }
}
