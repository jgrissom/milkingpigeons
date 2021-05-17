using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkingPigeons.Migrations
{
    public partial class TeamChallenges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamChallenges",
                columns: table => new
                {
                    TeamChallengeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChallenges", x => x.TeamChallengeId);
                    table.ForeignKey(
                        name: "FK_TeamChallenges_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamChallenges_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallenges_ChallengeId",
                table: "TeamChallenges",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallenges_TeamId",
                table: "TeamChallenges",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamChallenges");
        }
    }
}
