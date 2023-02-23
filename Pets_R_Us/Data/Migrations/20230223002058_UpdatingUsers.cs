using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets_R_Us.Data.Migrations
{
    public partial class UpdatingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playDates_AspNetUsers_UserId",
                table: "playDates");

            migrationBuilder.DropIndex(
                name: "IX_playDates_UserId",
                table: "playDates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "playDates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_playDates_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "playDates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_playDates_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "playDates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_playDates_UserId",
                table: "playDates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_playDates_AspNetUsers_UserId",
                table: "playDates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
