using System;
using System.Collections.Generic;
using Application.Persons;

namespace Application.FantasyLeagues
{
    public class FantasyLeagueDto
    {
        public Guid FantasyLeagueID { get; set; }
        public string LeagueName { get; set; }
        public string LeagueCaption { get; set; }
        public string LeagueLogo { get; set; }
        public bool? IsPublic { get; set; }
        public string LeagueKey { get; set; }
        public int NumberOfTeams { get; set; }

        public ICollection<FantasyLeagueAdminsDto> FantasyLeagueAdmins { get; set; }
        public ICollection<FantasyLeagueTeamDto> FantasyLeagueTeams { get; set; }
    }

    public class FantasyLeagueCreateDto
    {
        public string LeagueName { get; set; }
        public string LeagueCaption { get; set; }
        public string LeagueLogo { get; set; }
        public bool? IsPublic { get; set; }
        public string LeagueKey { get; set; }
        public int NumberOfTeams { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid AdminID { get; set; }
    }

    public class FantasyLeagueUpdateDto
    {

    }

    public class FantasyLeagueTeamDto
    {
        public Guid FantasyLeagueID { get; set; }
        public Guid FantasyTeamID { get; set; }
    }

    public class FantasyLeagueAdminsDto
    {
        public PersonDto Person { get; set; }
    }

    public class FantasyLeagueAdminDto
    {
        public Guid FantasyLeagueID { get; set; }
        public Guid PersonID { get; set; }
    }


}