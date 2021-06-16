using System;
using Application.Leagues;

namespace Application.Teams
{
    public class TeamDto
    {
        public Guid TeamID { get; set; }
        public int APIFootballID { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public LeagueDto League { get; set; }
    }
}