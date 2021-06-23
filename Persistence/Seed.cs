using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Countries.Any())
            {
                var country = new Country
                {
                    APIFootballID = 1,
                    CountryName = "Italy",
                    Flag = "https://media.api-sports.io/flags/it.svg",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                };
                await context.Countries.AddRangeAsync(country);
                await context.SaveChangesAsync();
            }

            if (!context.Leagues.Any())
            {
                var league = new League
                {
                    APIFootballID = 135,
                    LeagueName = "Serie A",
                    LeagueLogo = "https://media.api-sports.io/football/leagues/135.png",
                    CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,

                };
                await context.Leagues.AddRangeAsync(league);
                await context.SaveChangesAsync();
            }

            if (!context.Teams.Any())
            {
                var team = new Team
                {
                    APIFootballID = 489,
                    TeamName = "AC Milan",
                    TeamLogo = "https://media.api-sports.io/football/teams/489.png",
                    LeagueID = context.Leagues.Single(c => c.LeagueName == "Serie A").LeagueID,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,

                };
                await context.Teams.AddRangeAsync(team);
                await context.SaveChangesAsync();
            }

            if (!context.Persons.Any())
            {
                var persons = new List<Person>
                {
                    new Person
                    {
                        FirstName = "Waleed",
                        LastName = "Alvi",
                        DateOfBirth = new DateTime(1992, 2, 16),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    }
                };
                await context.Persons.AddRangeAsync(persons);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var user = new List<User>
                {
                    new User
                    {
                        PersonID = context.Persons.Single(c => c.FirstName == "Waleed").PersonID,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,

                    }
                };
            }

            if (!context.Players.Any())
            {
                var players = new List<Player>
                {
                    new Player
                    {
                        APIFootballID = 1,
                        FirstName = "Franck Yannick",
                        LastName = "Kessié",
                        PreferredName = "F. Kessié",
                        DateOfBirth = new DateTime(1996, 12, 19),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Midfielder",
                        Height = 183,
                        Weight = 74,
                        Injured = false,
                        Value = 10,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 51070,
                        FirstName = "Zlatan",
                        LastName = "Ibrahimović",
                        PreferredName = "Z. Ibrahimović",
                        DateOfBirth = new DateTime(1981, 10, 03),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Attacker",
                        Height = 195,
                        Weight = 95,
                        Injured = false,
                        Value = 12,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 1632,
                        FirstName = "Alessio",
                        LastName = "Romagnoli",
                        PreferredName = "A. Romagnoli",
                        DateOfBirth = new DateTime(1995, 01, 12),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 185,
                        Weight = 75,
                        Injured = false,
                        Value = 8,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                };

                await context.Players.AddRangeAsync(players);
                await context.SaveChangesAsync();
            }
        }
    }
}