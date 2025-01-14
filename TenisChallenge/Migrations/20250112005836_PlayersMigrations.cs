using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TenisChallenge.WebApi.Migrations
{
    public partial class PlayersMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "female_players",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    reaction_time = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_female_players", x => x.id);
                    table.ForeignKey(
                        name: "FK_female_players_players_id",
                        column: x => x.id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "male_players",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    strengh = table.Column<double>(type: "double precision", nullable: false),
                    speed = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_male_players", x => x.id);
                    table.ForeignKey(
                        name: "FK_male_players_players_id",
                        column: x => x.id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "female_players");

            migrationBuilder.DropTable(
                name: "male_players");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
