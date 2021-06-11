using System;

namespace Domain
{
    public class League
    {
        public Guid LeagueID { get; set; }
        public int APIFootballID { get; set; }
        public String LeagueName { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public Team Team { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}