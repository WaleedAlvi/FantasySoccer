using System;
using Application.Countries;

namespace Application.Leagues
{
    public class LeagueDto
    {
        public Guid LeagueID { get; set; }
        public int APIFootballID { get; set; }
        public string LeagueName { get; set; }
        public string LeagueLogo { get; set; }
        public CountryDto Country { get; set; }
    }
}