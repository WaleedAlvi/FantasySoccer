using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedCheckConstraintforFantasyTeamGoalieOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CHK_GoalieOne_Unique",
                table: "FantasyTeams",
                sql: "GoalieOneID <> GoalieTwoID AND \r\n									     GoalieOneID <> DefenderOneID AND\r\n										 GoalieOneID <> DefenderTwoID AND\r\n										 GoalieOneID <> DefenderThreeID AND\r\n										 GoalieOneID <> DefenderFourID AND\r\n										 GoalieOneID <> DefenderFiveID AND\r\n										 GoalieOneID <> MidfielderOneID AND\r\n										 GoalieOneID <> MidfielderTwoID AND\r\n										 GoalieOneID <> MidfielderThreeID AND\r\n										 GoalieOneID <> MidfielderFourID AND\r\n										 GoalieOneID <> MidfielderFiveID AND\r\n										 GoalieOneID <> ForwardOneID AND\r\n										 GoalieOneID <> ForwardTwoID AND\r\n										 GoalieOneID <> ForwardThreeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_GoalieOne_Unique",
                table: "FantasyTeams");
        }
    }
}
