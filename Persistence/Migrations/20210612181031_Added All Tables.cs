using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FantasyLeagues",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<Guid>(type: "TEXT", nullable: false),
                    LeagueName = table.Column<string>(type: "TEXT", nullable: false),
                    LeagueCaption = table.Column<string>(type: "TEXT", nullable: true),
                    LeagueLogo = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "Default League Logo"),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    LeagueKey = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfTeams = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 10)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyLeagues", x => x.FantasyLeagueID);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    FormationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FormationName = table.Column<string>(type: "TEXT", nullable: false),
                    DefenderCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MidfielderCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ForwardCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.FormationID);
                });

            migrationBuilder.CreateTable(
                name: "Matchdays",
                columns: table => new
                {
                    MatchdayID = table.Column<Guid>(type: "TEXT", nullable: false),
                    LeagueID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Season = table.Column<int>(type: "INTEGER", nullable: false),
                    MatchdayCount = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                name: "FantasyLeaguesAdmins",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "FantasyLeagueTeams",
                columns: table => new
                {
                    FantasyLeagueID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FantasyTeamID = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    MatchdayTeamConfigurationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FantasyTeamID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatchdayID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FormationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CaptainID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatchdayTeamID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchdayTeamConfigurations", x => x.MatchdayTeamConfigurationID);
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_FantasyTeams_FantasyTeamID",
                        column: x => x.FantasyTeamID,
                        principalTable: "FantasyTeams",
                        principalColumn: "FantasyTeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_Formations_FormationID",
                        column: x => x.FormationID,
                        principalTable: "Formations",
                        principalColumn: "FormationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_Matchdays_MatchdayID",
                        column: x => x.MatchdayID,
                        principalTable: "Matchdays",
                        principalColumn: "MatchdayID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeamConfigurations_Players_CaptainID",
                        column: x => x.CaptainID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchdayTeams",
                columns: table => new
                {
                    MatchdayTeamID = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatchdayTeamConfigurationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    GoalieID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerOneID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerTwoID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerThreeID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerFourID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerFiveID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerSixID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerSevenID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerEightID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerNineID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerTenID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BenchOneID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BenchTwoID = table.Column<Guid>(type: "TEXT", nullable: false),
                    BenchThreeID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchdayTeams", x => x.MatchdayTeamID);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_MatchdayTeamConfigurations_MatchdayTeamID",
                        column: x => x.MatchdayTeamID,
                        principalTable: "MatchdayTeamConfigurations",
                        principalColumn: "MatchdayTeamConfigurationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_BenchOneID",
                        column: x => x.BenchOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_BenchThreeID",
                        column: x => x.BenchThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_BenchTwoID",
                        column: x => x.BenchTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_GoalieID",
                        column: x => x.GoalieID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerEightID",
                        column: x => x.PlayerEightID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerFiveID",
                        column: x => x.PlayerFiveID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerFourID",
                        column: x => x.PlayerFourID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerNineID",
                        column: x => x.PlayerNineID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerOneID",
                        column: x => x.PlayerOneID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerSevenID",
                        column: x => x.PlayerSevenID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerSixID",
                        column: x => x.PlayerSixID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerTenID",
                        column: x => x.PlayerTenID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerThreeID",
                        column: x => x.PlayerThreeID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchdayTeams_Players_PlayerTwoID",
                        column: x => x.PlayerTwoID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_MatchdayTeams_PlayerEightID",
                table: "MatchdayTeams",
                column: "PlayerEightID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyLeaguesAdmins");

            migrationBuilder.DropTable(
                name: "FantasyLeagueTeams");

            migrationBuilder.DropTable(
                name: "MatchdayTeams");

            migrationBuilder.DropTable(
                name: "FantasyLeagues");

            migrationBuilder.DropTable(
                name: "MatchdayTeamConfigurations");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "Matchdays");
        }
    }
}
