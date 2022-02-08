using System;
using System.Collections.Generic;

#nullable disable

namespace eVoting.App.Models
{
    public partial class VotesHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime? VotedDateTime { get; set; }
    }
}
