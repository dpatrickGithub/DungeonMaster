using Microsoft.EntityFrameworkCore.Migrations;

namespace DungeonMaster.Data.Migrations
{
    public partial class FixClassDescriptionTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desription",
                table: "DNDClass",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DNDClass",
                newName: "Desription");
        }
    }
}
