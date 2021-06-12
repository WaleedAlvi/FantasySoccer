using System;

namespace Domain
{
    public class FantasyLeagueAdmin
    {
        public Guid FantasyLeagueID { get; set; }
        public Guid PersonID { get; set; }


        public FantasyLeague FantasyLeague { get; set; }
        public Person Person { get; set; }
    }
}