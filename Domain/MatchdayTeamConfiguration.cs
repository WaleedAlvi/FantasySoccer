using System;

namespace Domain
{
    public class MatchdayTeamConfiguration
    {
        public Guid MatchdayTeamConfigurationID { get; set; }
        public Guid FantasyTeamID { get; set; }
        public Guid MatchdayID { get; set; }
        public Guid FormationID { get; set; }
        public Guid CaptainID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Matchday Matchday { get; set; }
        public Formation Formation { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
        public Player Player { get; set; }
        public MatchdayTeam MatchdayTeam { get; set; }
    }
}