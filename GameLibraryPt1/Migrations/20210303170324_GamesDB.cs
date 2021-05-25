using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLibraryPt1.Migrations
{
    public partial class GamesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Games");
        }
    }
}
