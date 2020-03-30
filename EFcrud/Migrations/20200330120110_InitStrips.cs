using Microsoft.EntityFrameworkCore.Migrations;

namespace EFcrud.Migrations
{
    public partial class InitStrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurID);
                });

            migrationBuilder.CreateTable(
                name: "Reeksen",
                columns: table => new
                {
                    ReeksID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reeksen", x => x.ReeksID);
                });

            migrationBuilder.CreateTable(
                name: "Uitgeverijen",
                columns: table => new
                {
                    UitgeverijID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgeverijen", x => x.UitgeverijID);
                });

            migrationBuilder.CreateTable(
                name: "Strips",
                columns: table => new
                {
                    StripID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<int>(nullable: false),
                    Titel = table.Column<string>(nullable: true),
                    UitgeverijID = table.Column<int>(nullable: true),
                    ReeksID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strips", x => x.StripID);
                    table.ForeignKey(
                        name: "FK_Strips_Reeksen_ReeksID",
                        column: x => x.ReeksID,
                        principalTable: "Reeksen",
                        principalColumn: "ReeksID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Strips_Uitgeverijen_UitgeverijID",
                        column: x => x.UitgeverijID,
                        principalTable: "Uitgeverijen",
                        principalColumn: "UitgeverijID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuteurStrip",
                columns: table => new
                {
                    AuteurID = table.Column<int>(nullable: false),
                    StripID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurStrip", x => new { x.StripID, x.AuteurID });
                    table.ForeignKey(
                        name: "FK_AuteurStrip_Auteurs_AuteurID",
                        column: x => x.AuteurID,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurStrip_Strips_StripID",
                        column: x => x.StripID,
                        principalTable: "Strips",
                        principalColumn: "StripID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuteurStrip_AuteurID",
                table: "AuteurStrip",
                column: "AuteurID");

            migrationBuilder.CreateIndex(
                name: "IX_Strips_ReeksID",
                table: "Strips",
                column: "ReeksID");

            migrationBuilder.CreateIndex(
                name: "IX_Strips_UitgeverijID",
                table: "Strips",
                column: "UitgeverijID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuteurStrip");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Strips");

            migrationBuilder.DropTable(
                name: "Reeksen");

            migrationBuilder.DropTable(
                name: "Uitgeverijen");
        }
    }
}
