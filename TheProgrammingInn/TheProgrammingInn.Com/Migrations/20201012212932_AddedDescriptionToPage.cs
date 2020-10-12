using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class AddedDescriptionToPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Images_DispalyImageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_DispalyImageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DispalyImageId",
                table: "Pages");

            migrationBuilder.AddColumn<int>(
                name: "DisplayImageId",
                table: "Pages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DisplayImageId",
                table: "Pages",
                column: "DisplayImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Images_DisplayImageId",
                table: "Pages",
                column: "DisplayImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Images_DisplayImageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_DisplayImageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DisplayImageId",
                table: "Pages");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DispalyImageId",
                table: "Pages",
                type: "int",
                nullable: true);

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
    }
}
