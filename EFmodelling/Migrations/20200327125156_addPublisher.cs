using Microsoft.EntityFrameworkCore.Migrations;

namespace EFmodelling.Migrations
{
    public partial class addPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "BookInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookInfo_PublisherId",
                table: "BookInfo",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInfo_PublisherInfo_PublisherId",
                table: "BookInfo",
                column: "PublisherId",
                principalTable: "PublisherInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInfo_PublisherInfo_PublisherId",
                table: "BookInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookInfo_PublisherId",
                table: "BookInfo");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "BookInfo");
        }
    }
}
