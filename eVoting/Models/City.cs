using System;
using System.Collections.Generic;

#nullable disable

namespace eVoting.App.Models
{
    public partial class City
    {
        public City()
        {
            Parties = new HashSet<Party>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? InsertedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public virtual ICollection<Party> Parties { get; set; }
    }
}
