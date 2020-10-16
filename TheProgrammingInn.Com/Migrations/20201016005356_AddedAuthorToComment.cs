using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProgrammingInn.Com.Migrations
{
    public partial class AddedAuthorToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SubComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MainComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_ApplicationUserId",
                table: "SubComments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_ApplicationUserId",
                table: "MainComments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_AspNetUsers_ApplicationUserId",
                table: "MainComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComments_AspNetUsers_ApplicationUserId",
                table: "SubComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_AspNetUsers_ApplicationUserId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComments_AspNetUsers_ApplicationUserId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_SubComments_ApplicationUserId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_ApplicationUserId",
                table: "MainComments");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SubComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "MainComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
