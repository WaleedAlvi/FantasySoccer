using System;

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


        public League League { get; set; }
        public Person Person { get; set; }
        public Player Player { get; set; }
    }
}