using System;

namespace Domain
{
    public class Person
    {
        public Guid PersonID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}