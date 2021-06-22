using System;

namespace Application.Persons
{
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