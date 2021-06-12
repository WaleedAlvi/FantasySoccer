using System;
using System.Collections.Generic;

namespace Domain
{
    public class FantasyTeam
    {
        public Guid FantasyTeamID { get; set; }
        public string FantasyTeamLogo { get; set; }
        public Guid PersonID { get; set; }
        public double MoneyBalance { get; set; }
        public Guid GoalieOneID { get; set; }
        public Guid GoalieTwoID { get; set; }
        public Guid DefenderOneID { get; set; }
        public Guid DefenderTwoID { get; set; }
        public Guid DefenderThreeID { get; set; }
        public Guid DefenderFourID { get; set; }
        public Guid DefenderFiveID { get; set; }
        public Guid MidfielderOneID { get; set; }
        public Guid MidfielderTwoID { get; set; }
        public Guid MidfielderThreeID { get; set; }
        public Guid MidfielderFourID { get; set; }
        public Guid MidfielderFiveID { get; set; }
        public Guid ForwardOneID { get; set; }
        public Guid ForwardTwoID { get; set; }
        public Guid ForwardThreeID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }


        public Person Person { get; set; }
        public Player GoalieOne { get; set; }
        public Player GoalieTwo { get; set; }
        public Player DefenderOne { get; set; }
        public Player DefenderTwo { get; set; }
        public Player DefenderThree { get; set; }
        public Player DefenderFour { get; set; }
        public Player DefenderFive { get; set; }
        public Player MidfielderOne { get; set; }
        public Player MidfielderTwo { get; set; }
        public Player MidfielderThree { get; set; }
        public Player MidfielderFour { get; set; }
        public Player MidfielderFive { get; set; }
        public Player ForwardOne { get; set; }
        public Player ForwardTwo { get; set; }
        public Player ForwardThree { get; set; }
        public ICollection<FantasyLeagueTeams> FantasyLeagueTeams { get; set; }
        public ICollection<MatchdayTeamConfiguration> MatchdayTeamConfiguration { get; set; }


    }
}