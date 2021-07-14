using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemoveColumnfromMatchdayTeamConfigurationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchdayTeamConfigurations_MatchdayTeams_MatchdayTeamID",
                table: "MatchdayTeamConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_MatchdayTeamConfigurations_MatchdayTeamID",
                table: "MatchdayTeamConfigurations");

            migrationBuilder.DropColumn(
                name: "MatchdayTeamID",
                table: "MatchdayTeamConfigurations");

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_MatchdayTeamConfigurationID",
                table: "MatchdayTeams",
                column: "MatchdayTeamConfigurationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchdayTeams_MatchdayTeamConfigurations_MatchdayTeamConfigurationID",
                table: "MatchdayTeams",
                column: "MatchdayTeamConfigurationID",
                principalTable: "MatchdayTeamConfigurations",
                principalColumn: "MatchdayTeamConfigurationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchdayTeams_MatchdayTeamConfigurations_MatchdayTeamConfigurationID",
                table: "MatchdayTeams");

            migrationBuilder.DropIndex(
                name: "IX_MatchdayTeams_MatchdayTeamConfigurationID",
                table: "MatchdayTeams");

            migrationBuilder.AddColumn<Guid>(
                name: "MatchdayTeamID",
                table: "MatchdayTeamConfigurations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeamConfigurations_MatchdayTeamID",
                table: "MatchdayTeamConfigurations",
                column: "MatchdayTeamID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchdayTeamConfigurations_MatchdayTeams_MatchdayTeamID",
                table: "MatchdayTeamConfigurations",
                column: "MatchdayTeamID",
                principalTable: "MatchdayTeams",
                principalColumn: "MatchdayTeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
