using System;
using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public int APIFootballID { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public Guid LeagueID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public League League { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}