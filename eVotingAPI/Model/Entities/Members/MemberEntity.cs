using System;

namespace eVoting.Model.Entities.Members
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateString { get; set; }
        public string BirthPlace { get; set; }
        public bool? IsCandidate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
