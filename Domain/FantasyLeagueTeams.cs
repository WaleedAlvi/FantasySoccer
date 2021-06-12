using System;

namespace Domain
{
    public class FantasyLeagueTeams
    {
        public Guid FantasyLeagueID { get; set; }
        public Guid FantasyTeamID { get; set; }


        public FantasyLeague FantasyLeague { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
    }
}