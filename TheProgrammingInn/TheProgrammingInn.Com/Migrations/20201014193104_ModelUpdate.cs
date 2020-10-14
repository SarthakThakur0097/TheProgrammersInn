using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Blogs_BlogTitle",
                table: "MainComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_BlogTitle",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "BlogTitle",
                table: "MainComments");

            migrationBuilder.AddColumn<string>(
                name: "BlogId",
                table: "MainComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_MainCommentId",
                table: "SubComments",
                column: "MainCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_BlogId",
                table: "MainComments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Blogs_BlogId",
                table: "MainComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComments_MainComments_MainCommentId",
                table: "SubComments",
                column: "MainCommentId",
                principalTable: "MainComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Blogs_BlogId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComments_MainComments_MainCommentId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_SubComments_MainCommentId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_BlogId",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "MainComments");

            migrationBuilder.AddColumn<string>(
                name: "BlogTitle",
                table: "MainComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_BlogTitle",
                table: "MainComments",
                column: "BlogTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Blogs_BlogTitle",
                table: "MainComments",
                column: "BlogTitle",
                principalTable: "Blogs",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
