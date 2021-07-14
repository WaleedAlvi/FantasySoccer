using System;

namespace Application.Matchdays
{
    public class MatchdayTeamConfigDto
    {
        public Guid MatchdayTeamConfigurationID { get; set; }
        public Guid FantasyTeamID { get; set; }
        public Guid MatchdayID { get; set; }
        public Guid FormationID { get; set; }
        public Guid CaptainID { get; set; }
    }

    public class MatchdayTeamDto
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
        public Guid BenchFourID { get; set; }
    }

    public class MatchdayTeamMatchTeamConfigDto
    {
        public MatchdayTeamConfigDto MatchdayTeamConfig { get; set; }
        public MatchdayTeamDto MatchdayTeam { get; set; }
    }
}