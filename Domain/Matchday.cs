using System;
using System.Collections.Generic;

namespace Domain
{
    public class Matchday
    {
        public Guid MatchdayID { get; set; }
        public Guid LeagueID { get; set; }
        public int Season { get; set; }
        public int MatchdayCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public League League { get; set; }
        public ICollection<MatchdayTeamConfiguration> MatchdayTeamConfiguration { get; set; }
    }
}