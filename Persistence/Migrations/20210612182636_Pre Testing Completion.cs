using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PreTestingCompletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchdayTeams_Players_PlayerEightID",
                table: "MatchdayTeams");

            migrationBuilder.DropIndex(
                name: "IX_MatchdayTeams_PlayerEightID",
                table: "MatchdayTeams");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerNinePlayerID",
                table: "MatchdayTeams",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublic",
                table: "FantasyLeagues",
                type: "INTEGER",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerNinePlayerID",
                table: "MatchdayTeams",
                column: "PlayerNinePlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchdayTeams_Players_PlayerNinePlayerID",
                table: "MatchdayTeams",
                column: "PlayerNinePlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchdayTeams_Players_PlayerNinePlayerID",
                table: "MatchdayTeams");

            migrationBuilder.DropIndex(
                name: "IX_MatchdayTeams_PlayerNinePlayerID",
                table: "MatchdayTeams");

            migrationBuilder.DropColumn(
                name: "PlayerNinePlayerID",
                table: "MatchdayTeams");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublic",
                table: "FantasyLeagues",
                type: "INTEGER",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchdayTeams_PlayerEightID",
                table: "MatchdayTeams",
                column: "PlayerEightID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchdayTeams_Players_PlayerEightID",
                table: "MatchdayTeams",
                column: "PlayerEightID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
