using System;
using System.Collections.Generic;

#nullable disable

namespace eVoting.App.Models
{
    public partial class Party
    {
        public Party()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
