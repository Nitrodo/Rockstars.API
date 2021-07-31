using Microsoft.EntityFrameworkCore.Migrations;

namespace Rockstars.Infrastructure.Persistence.Migrations
{
    public partial class RemovedUniqueSongName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_Name",
                table: "Songs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Songs_Name",
                table: "Songs",
                column: "Name",
                unique: true);
        }
    }
}
