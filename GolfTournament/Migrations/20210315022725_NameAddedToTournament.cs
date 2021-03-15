using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfTournament.Migrations
{
    public partial class NameAddedToTournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tournaments",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tournaments");
        }
    }
}
