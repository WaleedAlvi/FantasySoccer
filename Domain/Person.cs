using System;
using System.Collections.Generic;

namespace Domain
{
    public class Person
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CountryID { get; set; }
        public Guid TeamID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Country Country { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
        public ICollection<FantasyTeam> FantasyTeams { get; set; }
        public ICollection<FantasyLeagueAdmin> FantasyLeagueAdmins { get; set; }
    }
}