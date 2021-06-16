using System;
using Application.Countries;
using Application.Teams;
using Domain;

namespace Application.Persons
{
    public class PersonDto
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CountryDto Country { get; set; }
        public TeamDto FavouriteTeam { get; set; }
        public UserDto User { get; set; }
    }
}