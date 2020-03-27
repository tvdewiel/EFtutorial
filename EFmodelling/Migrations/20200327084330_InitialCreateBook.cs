using Microsoft.EntityFrameworkCore.Migrations;

namespace EFmodelling.Migrations
{
    public partial class InitialCreateBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInfo",
                columns: table => new
                {
                    ISBN = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    NumberOfPages = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInfo", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "PublisherInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "varchar(500)", nullable: true),
                    Stars = table.Column<int>(nullable: false),
                    BookISBN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_BookInfo_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "BookInfo",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookISBN",
                table: "Review",
                column: "BookISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublisherInfo");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "BookInfo");
        }
    }
}
