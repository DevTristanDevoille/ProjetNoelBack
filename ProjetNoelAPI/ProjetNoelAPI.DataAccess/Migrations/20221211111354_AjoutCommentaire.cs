using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetNoelAPI.DataAccess.Migrations
{
    public partial class AjoutCommentaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Commentaire",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commentaire",
                table: "Ideas");
        }
    }
}
