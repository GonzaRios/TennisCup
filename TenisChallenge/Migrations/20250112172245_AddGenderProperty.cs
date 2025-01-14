using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenisChallenge.WebApi.Migrations
{
    public partial class AddGenderProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "players",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "players");
        }
    }
}
