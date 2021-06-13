using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangedCountryForeignKeyPropstoOnetoManyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_CountryID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_CountryID",
                table: "Leagues");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryID",
                table: "Players",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryID",
                table: "Persons",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CountryID",
                table: "Leagues",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_CountryID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_CountryID",
                table: "Leagues");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryID",
                table: "Players",
                column: "CountryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryID",
                table: "Persons",
                column: "CountryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CountryID",
                table: "Leagues",
                column: "CountryID",
                unique: true);
        }
    }
}
