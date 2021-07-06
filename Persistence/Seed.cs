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
                        FirebaseID = "cyR4PGb8trXFcVTus5Z2u2bpdBr2",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    }
                };

                await context.Users.AddRangeAsync(user);
                await context.SaveChangesAsync();
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
                    new Player
                    {
                        APIFootballID = 187,
                        FirstName = "Tommaso",
                        LastName = "Berni",
                        PreferredName = "T. Berni",
                        DateOfBirth = new DateTime(1983, 03, 06),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Goalkeeper",
                        Height = 185,
                        Weight = 80 ,
                        Injured = false,
                        Value = 3.5,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 1834,
                        FirstName = "Silvio",
                        LastName = "Proto",
                        PreferredName = "A. Romagnoli",
                        DateOfBirth = new DateTime(1983, 05, 23),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Goalkeeper",
                        Height = 187,
                        Weight = 77,
                        Injured = false,
                        Value = 2.8,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 793,
                        FirstName = "Diego",
                        LastName = "Perotti",
                        PreferredName = "D. Perotti",
                        DateOfBirth = new DateTime(1988, 07, 26),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Midfielder",
                        Height = 179,
                        Weight = 70,
                        Injured = false,
                        Value = 6.2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 1632,
                        FirstName = "Nehuén Mario",
                        LastName = "Paz",
                        PreferredName = "N. Paz",
                        DateOfBirth = new DateTime(1993, 04, 28),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 191,
                        Weight = 89,
                        Injured = false,
                        Value = 6,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 30798,
                        FirstName = "Hidde",
                        LastName = "ter Avest",
                        PreferredName = "H. ter Avest",
                        DateOfBirth = new DateTime(1997, 05, 20),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 182,
                        Weight = 78,
                        Injured = false,
                        Value = 5.5,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 30802,
                        FirstName = "Emmanuel",
                        LastName = "Agyemang-Badu",
                        PreferredName = "E. Agyemang-Badu",
                        DateOfBirth = new DateTime(1990, 12, 02),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Midfielder",
                        Height = 173,
                        Weight = 71,
                        Injured = false,
                        Value = 7.0,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 30985,
                        FirstName = "Nicolás Federico",
                        LastName = "Spolli",
                        PreferredName = "N. Spolli",
                        DateOfBirth = new DateTime(1983, 02, 20),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 193,
                        Weight = 88,
                        Injured = false,
                        Value = 6.4,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 31012,
                        FirstName = "Marcello",
                        LastName = "Gazzola",
                        PreferredName = "M. Gazzola",
                        DateOfBirth = new DateTime(1985, 04, 03),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 184,
                        Weight = 79,
                        Injured = false,
                        Value = 6.2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 30992,
                        FirstName = "Tomislav",
                        LastName = "Gomelt",
                        PreferredName = "A. Romagnoli",
                        DateOfBirth = new DateTime(1995, 01, 07),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 185,
                        Weight = 75,
                        Injured = false,
                        Value = 7.8,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 1632,
                        FirstName = "Theo Bernard François",
                        LastName = "Hernández",
                        PreferredName = "T. Hernández",
                        DateOfBirth = new DateTime(1997, 10, 06),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Defender",
                        Height = 184,
                        Weight = 81,
                        Injured = false,
                        Value = 10,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 31146,
                        FirstName = "Sandro",
                        LastName = "Tonali",
                        PreferredName = "S. Tonali",
                        DateOfBirth = new DateTime(2000, 05, 08),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Midfielder",
                        Height = 181,
                        Weight = 79,
                        Injured = false,
                        Value = 7.5,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 22236,
                        FirstName = "Rafael Alexandre",
                        LastName = "Conceição Leão",
                        PreferredName = "Rafael Leão",
                        DateOfBirth = new DateTime(1999, 06, 10),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Attacker",
                        Height = 188,
                        Weight = 81,
                        Injured = false,
                        Value = 8,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 114,
                        FirstName = "Adrien Sebastian",
                        LastName = "Perruchet Silva",
                        PreferredName = "Adrien Silva",
                        DateOfBirth = new DateTime(1989, 03, 15),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Midfielder",
                        Height = 175,
                        Weight = 69,
                        Injured = false,
                        Value = 6.2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Player
                    {
                        APIFootballID = 114,
                        FirstName = "Jarrod",
                        LastName = "Bowen",
                        PreferredName = "J. Bowen",
                        DateOfBirth = new DateTime(1996, 12, 20),
                        CountryID = context.Countries.Single(c => c.CountryName == "Italy").CountryID,
                        TeamID = context.Teams.Single(c => c.TeamName == "AC Milan").TeamID,
                        Position = "Attacker",
                        Height = 175,
                        Weight = 69,
                        Injured = false,
                        Value = 3.8,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },

                };

                await context.Players.AddRangeAsync(players);
                await context.SaveChangesAsync();
            }

            if (!context.Formations.Any())
            {
                var formations = new List<Formation>
                {
                    new Formation
                    {
                        FormationName = "4-3-3",
                        DefenderCount = 4,
                        MidfielderCount = 3,
                        ForwardCount = 3,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Formation
                    {
                        FormationName = "4-4-2",
                        DefenderCount = 4,
                        MidfielderCount = 4,
                        ForwardCount = 2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Formation
                    {
                        FormationName = "5-3-2",
                        DefenderCount = 5,
                        MidfielderCount = 3,
                        ForwardCount = 2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Formation
                    {
                        FormationName = "3-4-3",
                        DefenderCount = 3,
                        MidfielderCount = 4,
                        ForwardCount = 3,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Formation
                    {
                        FormationName = "3–5–2",
                        DefenderCount = 3,
                        MidfielderCount = 5,
                        ForwardCount = 2,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Formation
                    {
                        FormationName = "4–5–1",
                        DefenderCount = 4,
                        MidfielderCount = 5,
                        ForwardCount = 1,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                    new Formation
                    {
                        FormationName = "5–4–1",
                        DefenderCount = 5,
                        MidfielderCount = 4,
                        ForwardCount = 1,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                    },
                };

                await context.Formations.AddRangeAsync(formations);
                await context.SaveChangesAsync();
            }
        }
    }
}