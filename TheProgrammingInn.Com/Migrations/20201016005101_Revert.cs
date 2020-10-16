using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Blogs_BlogId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_MainCommentId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_BlogId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "SubComments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_MainCommentId",
                table: "SubComments",
                newName: "IX_SubComments_MainCommentId");

            migrationBuilder.AlterColumn<int>(
                name: "MainCommentId",
                table: "SubComments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SubComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubComments",
                table: "SubComments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MainComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BlogId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_BlogId",
                table: "MainComments",
                column: "BlogId");

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
                name: "FK_SubComments_MainComments_MainCommentId",
                table: "SubComments");

            migrationBuilder.DropTable(
                name: "MainComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubComments",
                table: "SubComments");

            migrationBuilder.RenameTable(
                name: "SubComments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_SubComments_MainCommentId",
                table: "Comment",
                newName: "IX_Comment_MainCommentId");

            migrationBuilder.AlterColumn<int>(
                name: "MainCommentId",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogId",
                table: "Comment",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Blogs_BlogId",
                table: "Comment",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_MainCommentId",
                table: "Comment",
                column: "MainCommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
