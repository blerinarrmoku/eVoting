using System;

namespace eVoting.Model.Entities.Votes
{
    public class Vote
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int Count { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
