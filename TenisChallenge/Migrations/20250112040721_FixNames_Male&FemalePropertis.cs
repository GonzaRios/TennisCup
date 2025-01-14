using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenisChallenge.WebApi.Migrations
{
    public partial class FixNames_MaleFemalePropertis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "male_players",
                newName: "name_m");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "female_players",
                newName: "name_f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name_m",
                table: "male_players",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "name_f",
                table: "female_players",
                newName: "name");
        }
    }
}
