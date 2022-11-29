using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetNoelAPI.DataAccess.Migrations
{
    public partial class RefonteArchi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Squades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IdCreator = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: true),
                    IdSquad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listes_Squades_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Listes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SquadUser",
                columns: table => new
                {
                    SquadesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadUser", x => new { x.SquadesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SquadUser_Squades_SquadesId",
                        column: x => x.SquadesId,
                        principalTable: "Squades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SquadUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: true),
                    UrlIdea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTake = table.Column<bool>(type: "bit", nullable: false),
                    ListeId = table.Column<int>(type: "int", nullable: true),
                    IdListe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ideas_Listes_ListeId",
                        column: x => x.ListeId,
                        principalTable: "Listes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ListeId",
                table: "Ideas",
                column: "ListeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listes_SquadId",
                table: "Listes",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_Listes_UserId",
                table: "Listes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadUser_UsersId",
                table: "SquadUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "SquadUser");

            migrationBuilder.DropTable(
                name: "Listes");

            migrationBuilder.DropTable(
                name: "Squades");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
