using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetNoelAPI.DataAccess.Migrations
{
    public partial class AjoutOrdre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Ideas");
        }
    }
}
