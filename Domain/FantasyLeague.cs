using System;
using System.Collections.Generic;

namespace Domain
{
    public class FantasyLeague
    {
        public Guid FantasyLeagueID { get; set; }
        public string LeagueName { get; set; }
        public string LeagueCaption { get; set; }
        public string LeagueLogo { get; set; }
        public bool? IsPublic { get; set; }
        public string LeagueKey { get; set; }
        public int NumberOfTeams { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public ICollection<FantasyLeagueAdmin> FantasyLeagueAdmins { get; set; }
        public ICollection<FantasyLeagueTeams> FantasyLeagueTeams { get; set; }
    }
}