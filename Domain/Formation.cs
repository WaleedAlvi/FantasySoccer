using System;
using System.Collections.Generic;

namespace Domain
{
    public class Formation
    {
        public Guid FormationID { get; set; }
        public string FormationName { get; set; }
        public int DefenderCount { get; set; }
        public int MidfielderCount { get; set; }
        public int ForwardCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public ICollection<MatchdayTeamConfiguration> MatchdayTeamConfiguration { get; set; }
    }
}