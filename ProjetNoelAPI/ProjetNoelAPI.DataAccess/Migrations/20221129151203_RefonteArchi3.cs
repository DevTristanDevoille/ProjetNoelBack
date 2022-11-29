using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetNoelAPI.DataAccess.Migrations
{
    public partial class RefonteArchi3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listes_Users_UserId",
                table: "Listes");

            migrationBuilder.DropIndex(
                name: "IX_Listes_UserId",
                table: "Listes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Listes");

            migrationBuilder.CreateIndex(
                name: "IX_Listes_IdCreator",
                table: "Listes",
                column: "IdCreator");

            migrationBuilder.AddForeignKey(
                name: "FK_Listes_Users_IdCreator",
                table: "Listes",
                column: "IdCreator",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listes_Users_IdCreator",
                table: "Listes");

            migrationBuilder.DropIndex(
                name: "IX_Listes_IdCreator",
                table: "Listes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Listes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listes_UserId",
                table: "Listes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listes_Users_UserId",
                table: "Listes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
