using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkingPigeons.Migrations
{
    public partial class AlterChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "Pin",
                table: "Challenges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Challenges");

            migrationBuilder.AddColumn<int>(
                name: "Pin",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
