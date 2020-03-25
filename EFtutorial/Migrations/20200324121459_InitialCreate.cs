using Microsoft.EntityFrameworkCore.Migrations;

namespace EFtutorial.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uitgeverijen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    EmailContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgeverijen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boeken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true),
                    UitgeverijId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boeken_Uitgeverijen_UitgeverijId",
                        column: x => x.UitgeverijId,
                        principalTable: "Uitgeverijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    EmailContact = table.Column<string>(nullable: true),
                    BoekId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auteurs_Boeken_BoekId",
                        column: x => x.BoekId,
                        principalTable: "Boeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auteurs_BoekId",
                table: "Auteurs",
                column: "BoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_UitgeverijId",
                table: "Boeken",
                column: "UitgeverijId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Boeken");

            migrationBuilder.DropTable(
                name: "Uitgeverijen");
        }
    }
}
