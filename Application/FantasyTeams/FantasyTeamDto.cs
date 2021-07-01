using System;
using Application.Persons;
using Application.Players;

namespace Application.FantasyTeams
{
    public class FantasyTeamDto
    {
        public Guid FantasyTeamID { get; set; }
        public string FantasyTeamName { get; set; }
        public string FantasyTeamLogo { get; set; }
        public PersonDto Person { get; set; }
        public double MoneyBalance { get; set; }
        public PlayerDto GoalieOne { get; set; }
        public PlayerDto GoalieTwo { get; set; }
        public PlayerDto DefenderOne { get; set; }
        public PlayerDto DefenderTwo { get; set; }
        public PlayerDto DefenderThree { get; set; }
        public PlayerDto DefenderFour { get; set; }
        public PlayerDto DefenderFive { get; set; }
        public PlayerDto MidfielderOne { get; set; }
        public PlayerDto MidfielderTwo { get; set; }
        public PlayerDto MidfielderThree { get; set; }
        public PlayerDto MidfielderFour { get; set; }
        public PlayerDto MidfielderFive { get; set; }
        public PlayerDto ForwardOne { get; set; }
        public PlayerDto ForwardTwo { get; set; }
        public PlayerDto ForwardThree { get; set; }
    }
}