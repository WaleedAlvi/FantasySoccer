using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangedTeamForeignKeyPropstoOnetoManyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_TeamID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TeamID",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamID",
                table: "Persons",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_TeamID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Persons_TeamID",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TeamID",
                table: "Persons",
                column: "TeamID",
                unique: true);
        }
    }
}
