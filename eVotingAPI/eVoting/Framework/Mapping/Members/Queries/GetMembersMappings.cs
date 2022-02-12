using AutoMapper;

namespace eVoting.App.Framework.Mapping.Members.Queries
{
    public class GetMembersMappings : Profile
    {
        public GetMembersMappings()
        {
            CreateMap<Models.Member, Model.Entities.Members.MemberEntity>();
        }
    }
}
