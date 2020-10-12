using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class ImageClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DispalyImageId",
                table: "Pages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DispalyImageId",
                table: "Pages",
                column: "DispalyImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Images_DispalyImageId",
                table: "Pages",
                column: "DispalyImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Images_DispalyImageId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Pages_DispalyImageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DispalyImageId",
                table: "Pages");
        }
    }
}
