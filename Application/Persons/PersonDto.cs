using System;
using Application.Countries;
using Application.Teams;

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

    public class UserDto
    {
        public string FirebaseID { get; set; }
    }

    public class PersonUserDto
    {
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CountryID { get; set; }
        public Guid TeamID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string FireBaseID { get; set; }

    }
}