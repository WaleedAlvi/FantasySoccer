using System;
using Application.Countries;
using Application.Teams;

namespace Application.Players
{
    public class PlayerDto
    {
        public Guid PlayerID { get; set; }
        public int APIFootballID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CountryDto Country { get; set; }
        public Guid TeamID { get; set; }
        public TeamDto Team { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool Injured { get; set; }
        public double Value { get; set; }
    }
}