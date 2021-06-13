using System;
using System.Collections.Generic;

namespace Domain
{
    public class Country
    {
        public Guid CountryID { get; set; }
        public int APIFootballID { get; set; }
        public string CountryName { get; set; }
        public string Flag { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public ICollection<League> League { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}