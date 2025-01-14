using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenisChallenge.WebApi.Migrations
{
    public partial class AddNewPlayersPropertis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "female",
                table: "players",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "male",
                table: "players",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "players",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "female",
                table: "players");

            migrationBuilder.DropColumn(
                name: "male",
                table: "players");

            migrationBuilder.DropColumn(
                name: "name",
                table: "players");
        }
    }
}
