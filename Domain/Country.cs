using System;

namespace Domain
{
    public class Country
    {
        public Guid CountryID { get; set; }
        public int APIFootballID { get; set; }
        public String CountryName { get; set; }
        public String Flag { get; set; }
        public League League { get; set; }
        public Person Person { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}