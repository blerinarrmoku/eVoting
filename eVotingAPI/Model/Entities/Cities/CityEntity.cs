using System;

namespace eVoting.Model.Entities.Cities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? InsertedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

    }
}
