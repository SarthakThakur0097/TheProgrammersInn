using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class addedKeyPropToBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Blogs",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "BlogId",
                table: "MainComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId1",
                table: "MainComments",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Blogs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Blogs",
                newName: "dateTime");

            migrationBuilder.AlterColumn<string>(
                name: "BlogId",
                table: "MainComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
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
    }
}
