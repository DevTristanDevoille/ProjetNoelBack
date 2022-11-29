using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetNoelAPI.DataAccess.Migrations
{
    public partial class RefonteArchi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Listes_ListeId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Listes_Squades_SquadId",
                table: "Listes");

            migrationBuilder.DropIndex(
                name: "IX_Listes_SquadId",
                table: "Listes");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_ListeId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Listes");

            migrationBuilder.DropColumn(
                name: "ListeId",
                table: "Ideas");

            migrationBuilder.CreateIndex(
                name: "IX_Listes_IdSquad",
                table: "Listes",
                column: "IdSquad");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_IdListe",
                table: "Ideas",
                column: "IdListe");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Listes_IdListe",
                table: "Ideas",
                column: "IdListe",
                principalTable: "Listes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listes_Squades_IdSquad",
                table: "Listes",
                column: "IdSquad",
                principalTable: "Squades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Listes_IdListe",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Listes_Squades_IdSquad",
                table: "Listes");

            migrationBuilder.DropIndex(
                name: "IX_Listes_IdSquad",
                table: "Listes");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_IdListe",
                table: "Ideas");

            migrationBuilder.AddColumn<int>(
                name: "SquadId",
                table: "Listes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListeId",
                table: "Ideas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listes_SquadId",
                table: "Listes",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ListeId",
                table: "Ideas",
                column: "ListeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Listes_ListeId",
                table: "Ideas",
                column: "ListeId",
                principalTable: "Listes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listes_Squades_SquadId",
                table: "Listes",
                column: "SquadId",
                principalTable: "Squades",
                principalColumn: "Id");
        }
    }
}
