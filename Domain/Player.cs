using System;
using System.Collections.Generic;

namespace Domain
{
    public class Player
    {
        public Guid PlayerID { get; set; }
        public int APIFootballID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CountryID { get; set; }
        public Guid TeamID { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool Injured { get; set; }
        public double Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Country Country { get; set; }
        public Team Team { get; set; }
        public ICollection<FantasyTeam> GoalieOneFantasyTeams { get; set; }
        public ICollection<FantasyTeam> GoalieTwoFantasyTeams { get; set; }
        public ICollection<FantasyTeam> DefenderOneFantasyTeams { get; set; }
        public ICollection<FantasyTeam> DefenderTwoFantasyTeams { get; set; }
        public ICollection<FantasyTeam> DefenderThreeFantasyTeams { get; set; }
        public ICollection<FantasyTeam> DefenderFourFantasyTeams { get; set; }
        public ICollection<FantasyTeam> DefenderFiveFantasyTeams { get; set; }
        public ICollection<FantasyTeam> MidfielderOneFantasyTeams { get; set; }
        public ICollection<FantasyTeam> MidfielderTwoFantasyTeams { get; set; }
        public ICollection<FantasyTeam> MidfielderThreeFantasyTeams { get; set; }
        public ICollection<FantasyTeam> MidfielderFourFantasyTeams { get; set; }
        public ICollection<FantasyTeam> MidfielderFiveFantasyTeams { get; set; }
        public ICollection<FantasyTeam> ForwardOneFantasyTeams { get; set; }
        public ICollection<FantasyTeam> ForwardTwoFantasyTeams { get; set; }
        public ICollection<FantasyTeam> ForwardThreeFantasyTeams { get; set; }
        public ICollection<FantasyTeam> ForwardFourFantasyTeams { get; set; }
        public ICollection<FantasyTeam> ForwardFiveFantasyTeams { get; set; }
        public ICollection<MatchdayTeamConfiguration> MatchdayTeamConfiguration { get; set; }
        public ICollection<MatchdayTeam> GoalieMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerOneMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerTwoMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerThreeMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerFourMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerFiveMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerSixMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerSevenMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerEightMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerNineMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> PlayerTenMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> BenchOneMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> BenchTwoMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> BenchThreeMatchdayTeams { get; set; }
        public ICollection<MatchdayTeam> BenchFourMatchdayTeams { get; set; }

    }
}