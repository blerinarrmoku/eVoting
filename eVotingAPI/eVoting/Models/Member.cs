using System;
using System.Collections.Generic;

#nullable disable

namespace eVoting.App.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool? IsCandidate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual Party Party { get; set; }
    }
}
