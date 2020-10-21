using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class RevertKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Blogs_BlogId1",
                table: "MainComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_BlogId1",
                table: "MainComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "BlogId",
                table: "MainComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Title");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Blogs_BlogId",
                table: "MainComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_BlogId",
                table: "MainComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "BlogId",
                table: "MainComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId1",
                table: "MainComments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_BlogId1",
                table: "MainComments",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Blogs_BlogId1",
                table: "MainComments",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
