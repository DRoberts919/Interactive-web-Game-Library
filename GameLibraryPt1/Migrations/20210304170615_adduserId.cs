using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLibraryPt1.Migrations
{
    public partial class adduserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Games",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Games",
                newName: "userId");
        }
    }
}
