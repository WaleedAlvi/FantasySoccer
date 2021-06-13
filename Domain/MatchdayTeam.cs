using System;

namespace Domain
{
    public class MatchdayTeam
    {
        public Guid MatchdayTeamID { get; set; }
        public Guid MatchdayTeamConfigurationID { get; set; }
        public Guid GoalieID { get; set; }
        public Guid PlayerOneID { get; set; }
        public Guid PlayerTwoID { get; set; }
        public Guid PlayerThreeID { get; set; }
        public Guid PlayerFourID { get; set; }
        public Guid PlayerFiveID { get; set; }
        public Guid PlayerSixID { get; set; }
        public Guid PlayerSevenID { get; set; }
        public Guid PlayerEightID { get; set; }
        public Guid PlayerNineID { get; set; }
        public Guid PlayerTenID { get; set; }
        public Guid BenchOneID { get; set; }
        public Guid BenchTwoID { get; set; }
        public Guid BenchThreeID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Player Goalie { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player PlayerThree { get; set; }
        public Player PlayerFour { get; set; }
        public Player PlayerFive { get; set; }
        public Player PlayerSix { get; set; }
        public Player PlayerSeven { get; set; }
        public Player PlayerEight { get; set; }
        public Player PlayerNine { get; set; }
        public Player PlayerTen { get; set; }
        public Player BenchOne { get; set; }
        public Player BenchTwo { get; set; }
        public Player BenchThree { get; set; }
        public MatchdayTeamConfiguration MatchdayTeamConfiguration { get; set; }
    }
}