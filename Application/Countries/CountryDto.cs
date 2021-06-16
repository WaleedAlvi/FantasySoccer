using System;

namespace Application.Countries
{
    public class CountryDto
    {
        public Guid CountryID { get; set; }
        public int APIFootballID { get; set; }
        public string CountryName { get; set; }
        public string Flag { get; set; }
    }
}