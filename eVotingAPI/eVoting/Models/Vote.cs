using System;
using System.Collections.Generic;

#nullable disable

namespace eVoting.App.Models
{
    public partial class Vote
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int Count { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual Member Member { get; set; }
    }
}
