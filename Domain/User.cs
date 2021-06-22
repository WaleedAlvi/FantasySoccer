using System;

namespace Domain
{
    public class User
    {
        public Guid UserID { get; set; }
        public string FirebaseID { get; set; }
        public Guid PersonID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Person Person { get; set; }
    }
}