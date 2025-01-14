using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenisChallenge.WebApi.Migrations
{
    public partial class AddName_MaleFemalePropertis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "male_players",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "female_players",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "male_players");

            migrationBuilder.DropColumn(
                name: "name",
                table: "female_players");
        }
    }
}
