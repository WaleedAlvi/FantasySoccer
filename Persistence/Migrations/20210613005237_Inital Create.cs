using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    APIFootballID = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "FantasyLeagues",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueLogo = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Default League Logo"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    LeagueKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfTeams = table.Column<int>(type: "int", nullable: false, defaultValue: 10)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyLeagues", x => x.FantasyLeagueID);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    FormationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefenderCount = table.Column<int>(type: "int", nullable: false),
                    MidfielderCount = table.Column<int>(type: "int", nullable: false),
                    ForwardCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.FormationID);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    APIFootballID = table.Column<int>(type: "int", nullable: false),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueID);
                    table.ForeignKey(
                        name: "FK_Leagues_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matchdays",
                columns: table => new
                {
                    MatchdayID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    MatchdayCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchdays", x => x.MatchdayID);
                    table.ForeignKey(
                        name: "FK_Matchdays_Leagues_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "Leagues",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    APIFootballID = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "Leagues",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Persons_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                    table.ForeignKey(
                        name: "FK_Persons_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    APIFootballID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Injured = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateTable(
                name: "FantasyLeaguesAdmins",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyLeaguesAdmins", x => new { x.FantasyLeagueID, x.PersonID });
                    table.ForeignKey(
                        name: "FK_FantasyLeaguesAdmins_FantasyLeagues_FantasyLeagueID",
                        column: x => x.FantasyLeagueID,
                        principalTable: "FantasyLeagues",
                        principalColumn: "FantasyLeagueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyLeaguesAdmins_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirebaseID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FantasyTeams",
                columns: table => new
                {
                    FantasyTeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FantasyTeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Hello World, This  is an image"),
                    PersonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoneyBalance = table.Column<double>(type: "float", nullable: false),
                    GoalieOneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalieTwoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefenderOneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefenderTwoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefenderThreeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefenderFourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefenderFiveID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MidfielderOneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MidfielderTwoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MidfielderThreeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MidfielderFourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MidfielderFiveID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForwardOneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForwardTwoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForwardThreeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlayerID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyTeams", x => x.FantasyTeamID);
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_DefenderFiveID",
                        column: x => x.DefenderFiveID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_DefenderFourID",
                        column: x => x.DefenderFourID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_DefenderOneID",
                        column: x => x.DefenderOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_DefenderThreeID",
                        column: x => x.DefenderThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_DefenderTwoID",
                        column: x => x.DefenderTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_ForwardOneID",
                        column: x => x.ForwardOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_ForwardThreeID",
                        column: x => x.ForwardThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_ForwardTwoID",
                        column: x => x.ForwardTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_GoalieOneID",
                        column: x => x.GoalieOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_GoalieTwoID",
                        column: x => x.GoalieTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_MidfielderFiveID",
                        column: x => x.MidfielderFiveID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_MidfielderFourID",
                        column: x => x.MidfielderFourID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_MidfielderOneID",
                        column: x => x.MidfielderOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_MidfielderThreeID",
                        column: x => x.MidfielderThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_MidfielderTwoID",
                        column: x => x.MidfielderTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FantasyTeams_Players_PlayerID1",
                        column: x => x.PlayerID1,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchdayTeams",
                columns: table => new
                {
                    MatchdayTeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchdayTeamConfigurationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalieID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerOneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerTwoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerThreeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerFourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerFiveID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerSixID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerSevenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerEightID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerNineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerTenID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenchOneID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenchTwoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenchThreeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerNinePlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchdayTeams", x => x.MatchdayTeamID);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_BenchOneID",
                        column: x => x.BenchOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_BenchThreeID",
                        column: x => x.BenchThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_BenchTwoID",
                        column: x => x.BenchTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_GoalieID",
                        column: x => x.GoalieID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerFiveID",
                        column: x => x.PlayerFiveID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerFourID",
                        column: x => x.PlayerFourID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerNineID",
                        column: x => x.PlayerNineID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerNinePlayerID",
                        column: x => x.PlayerNinePlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerOneID",
                        column: x => x.PlayerOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerSevenID",
                        column: x => x.PlayerSevenID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerSixID",
                        column: x => x.PlayerSixID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerTenID",
                        column: x => x.PlayerTenID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerThreeID",
                        column: x => x.PlayerThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerTwoID",
                        column: x => x.PlayerTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                });

            migrationBuilder.CreateTable(
                name: "FantasyLeagueTeams",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FantasyTeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyLeagueTeams", x => new { x.FantasyLeagueID, x.FantasyTeamID });
                    table.ForeignKey(
                        name: "FK_FantasyLeagueTeams_FantasyLeagues_FantasyLeagueID",
                        column: x => x.FantasyLeagueID,
                        principalTable: "FantasyLeagues",
                        principalColumn: "FantasyLeagueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyLeagueTeams_FantasyTeams_FantasyTeamID",
                        column: x => x.FantasyTeamID,
                        principalTable: "FantasyTeams",
                        principalColumn: "FantasyTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchdayTeamConfigurations",
                columns: table => new
                {
                    MatchdayTeamConfigurationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FantasyTeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchdayID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaptainID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchdayTeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchdayTeamConfigurations", x => x.MatchdayTeamConfigurationID);
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_FantasyTeams_FantasyTeamID",
                        column: x => x.FantasyTeamID,
                        principalTable: "FantasyTeams",
                        principalColumn: "FantasyTeamID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_Formations_FormationID",
                        column: x => x.FormationID,
                        principalTable: "Formations",
                        principalColumn: "FormationID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_Matchdays_MatchdayID",
                        column: x => x.MatchdayID,
                        principalTable: "Matchdays",
                        principalColumn: "MatchdayID");
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_MatchdayTeams_MatchdayTeamID",
                        column: x => x.MatchdayTeamID,
                        principalTable: "MatchdayTeams",
                        principalColumn: "MatchdayTeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_Players_CaptainID",
                        column: x => x.CaptainID,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeaguesAdmins_PersonID",
                table: "FantasyLeaguesAdmins",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyLeagueTeams_FantasyTeamID",
                table: "FantasyLeagueTeams",
                column: "FantasyTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderFiveID",
                table: "FantasyTeams",
                column: "DefenderFiveID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderFourID",
                table: "FantasyTeams",
                column: "DefenderFourID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderOneID",
                table: "FantasyTeams",
                column: "DefenderOneID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderThreeID",
                table: "FantasyTeams",
                column: "DefenderThreeID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderTwoID",
                table: "FantasyTeams",
                column: "DefenderTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_ForwardOneID",
                table: "FantasyTeams",
                column: "ForwardOneID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_ForwardThreeID",
                table: "FantasyTeams",
                column: "ForwardThreeID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_ForwardTwoID",
                table: "FantasyTeams",
                column: "ForwardTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_GoalieOneID",
                table: "FantasyTeams",
                column: "GoalieOneID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_GoalieTwoID",
                table: "FantasyTeams",
                column: "GoalieTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_MidfielderFiveID",
                table: "FantasyTeams",
                column: "MidfielderFiveID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_MidfielderFourID",
                table: "FantasyTeams",
                column: "MidfielderFourID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_MidfielderOneID",
                table: "FantasyTeams",
                column: "MidfielderOneID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_MidfielderThreeID",
                table: "FantasyTeams",
                column: "MidfielderThreeID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_MidfielderTwoID",
                table: "FantasyTeams",
                column: "MidfielderTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_PersonID",
                table: "FantasyTeams",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_PlayerID",
                table: "FantasyTeams",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_PlayerID1",
                table: "FantasyTeams",
                column: "PlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CountryID",
                table: "Leagues",
                column: "CountryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matchdays_LeagueID",
                table: "Matchdays",
                column: "LeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeamConfigurations_CaptainID",
                table: "MatchdayTeamConfigurations",
                column: "CaptainID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeamConfigurations_FantasyTeamID",
                table: "MatchdayTeamConfigurations",
                column: "FantasyTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeamConfigurations_FormationID",
                table: "MatchdayTeamConfigurations",
                column: "FormationID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeamConfigurations_MatchdayID",
                table: "MatchdayTeamConfigurations",
                column: "MatchdayID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeamConfigurations_MatchdayTeamID",
                table: "MatchdayTeamConfigurations",
                column: "MatchdayTeamID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_BenchOneID",
                table: "MatchdayTeams",
                column: "BenchOneID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_BenchThreeID",
                table: "MatchdayTeams",
                column: "BenchThreeID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_BenchTwoID",
                table: "MatchdayTeams",
                column: "BenchTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_GoalieID",
                table: "MatchdayTeams",
                column: "GoalieID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerFiveID",
                table: "MatchdayTeams",
                column: "PlayerFiveID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerFourID",
                table: "MatchdayTeams",
                column: "PlayerFourID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerNineID",
                table: "MatchdayTeams",
                column: "PlayerNineID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerNinePlayerID",
                table: "MatchdayTeams",
                column: "PlayerNinePlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerOneID",
                table: "MatchdayTeams",
                column: "PlayerOneID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerSevenID",
                table: "MatchdayTeams",
                column: "PlayerSevenID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerSixID",
                table: "MatchdayTeams",
                column: "PlayerSixID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerTenID",
                table: "MatchdayTeams",
                column: "PlayerTenID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerThreeID",
                table: "MatchdayTeams",
                column: "PlayerThreeID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerTwoID",
                table: "MatchdayTeams",
                column: "PlayerTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryID",
                table: "Persons",
                column: "CountryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamID",
                table: "Persons",
                column: "TeamID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryID",
                table: "Players",
                column: "CountryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueID",
                table: "Teams",
                column: "LeagueID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonID",
                table: "Users",
                column: "PersonID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyLeaguesAdmins");

            migrationBuilder.DropTable(
                name: "FantasyLeagueTeams");

            migrationBuilder.DropTable(
                name: "MatchdayTeamConfigurations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FantasyLeagues");

            migrationBuilder.DropTable(
                name: "FantasyTeams");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "Matchdays");

            migrationBuilder.DropTable(
                name: "MatchdayTeams");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
