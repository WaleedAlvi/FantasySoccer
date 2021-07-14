using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedColumntoMatchdayTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BenchFourID",
                table: "MatchdayTeams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_BenchFourID",
                table: "MatchdayTeams",
                column: "BenchFourID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchdayTeams_Players_BenchFourID",
                table: "MatchdayTeams",
                column: "BenchFourID",
                principalTable: "Players",
                principalColumn: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchdayTeams_Players_BenchFourID",
                table: "MatchdayTeams");

            migrationBuilder.DropIndex(
                name: "IX_MatchdayTeams_BenchFourID",
                table: "MatchdayTeams");

            migrationBuilder.DropColumn(
                name: "BenchFourID",
                table: "MatchdayTeams");
        }
    }
}
