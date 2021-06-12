using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedFantasyPlayersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PersonID",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeagueID",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamID",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryID",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamID",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryID",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryID",
                table: "Leagues",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<Guid>(
                name: "DefenderFiveID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DefenderFourID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DefenderThreeID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForwardOneID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForwardThreeID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForwardTwoID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MidfielderFiveID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MidfielderFourID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MidfielderOneID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MidfielderThreeID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MidfielderTwoID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerID",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerID1",
                table: "FantasyTeams",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderFiveID",
                table: "FantasyTeams",
                column: "DefenderFiveID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderFourID",
                table: "FantasyTeams",
                column: "DefenderFourID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_DefenderThreeID",
                table: "FantasyTeams",
                column: "DefenderThreeID");

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
                name: "IX_FantasyTeams_PlayerID",
                table: "FantasyTeams",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeams_PlayerID1",
                table: "FantasyTeams",
                column: "PlayerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_DefenderFiveID",
                table: "FantasyTeams",
                column: "DefenderFiveID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_DefenderFourID",
                table: "FantasyTeams",
                column: "DefenderFourID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_DefenderThreeID",
                table: "FantasyTeams",
                column: "DefenderThreeID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_ForwardOneID",
                table: "FantasyTeams",
                column: "ForwardOneID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_ForwardThreeID",
                table: "FantasyTeams",
                column: "ForwardThreeID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_ForwardTwoID",
                table: "FantasyTeams",
                column: "ForwardTwoID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderFiveID",
                table: "FantasyTeams",
                column: "MidfielderFiveID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderFourID",
                table: "FantasyTeams",
                column: "MidfielderFourID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderOneID",
                table: "FantasyTeams",
                column: "MidfielderOneID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderThreeID",
                table: "FantasyTeams",
                column: "MidfielderThreeID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderTwoID",
                table: "FantasyTeams",
                column: "MidfielderTwoID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_PlayerID",
                table: "FantasyTeams",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyTeams_Players_PlayerID1",
                table: "FantasyTeams",
                column: "PlayerID1",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_DefenderFiveID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_DefenderFourID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_DefenderThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_ForwardOneID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_ForwardThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_ForwardTwoID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderFiveID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderFourID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderOneID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_MidfielderTwoID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_PlayerID",
                table: "FantasyTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyTeams_Players_PlayerID1",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_DefenderFiveID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_DefenderFourID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_DefenderThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_ForwardOneID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_ForwardThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_ForwardTwoID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_MidfielderFiveID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_MidfielderFourID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_MidfielderOneID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_MidfielderThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_MidfielderTwoID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_PlayerID",
                table: "FantasyTeams");

            migrationBuilder.DropIndex(
                name: "IX_FantasyTeams_PlayerID1",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "DefenderFiveID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "DefenderFourID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "DefenderThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "ForwardOneID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "ForwardThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "ForwardTwoID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "MidfielderFiveID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "MidfielderFourID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "MidfielderOneID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "MidfielderThreeID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "MidfielderTwoID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "FantasyTeams");

            migrationBuilder.DropColumn(
                name: "PlayerID1",
                table: "FantasyTeams");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "LeagueID",
                table: "Teams",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Leagues",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");
        }
    }
}
