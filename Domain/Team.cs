using System;

namespace Domain
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public int APIFootballID { get; set; }
        public String TeamName { get; set; }
        public int LeagueID { get; set; }
        public League League { get; set; }
        public Person Person { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}