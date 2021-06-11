using System;

namespace Domain
{
    public class User
    {
        public Guid UserID { get; set; }
        public int FirebaseID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}