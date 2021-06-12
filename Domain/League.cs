using System;
using System.Collections.Generic;

namespace Domain
{
    public class League
    {
        public Guid LeagueID { get; set; }
        public int APIFootballID { get; set; }
        public string LeagueName { get; set; }
        public string LeagueLogo { get; set; }
        public Guid CountryID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Country Country { get; set; }
        public Team Team { get; set; }
        public ICollection<Matchday> MatchDays { get; set; }
    }
}