using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets_R_Us.Data.Migrations
{
    public partial class MakingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "playDates");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "playDates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_playDates_UsersId",
                table: "playDates",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_playDates_AspNetUsers_UsersId",
                table: "playDates",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playDates_AspNetUsers_UsersId",
                table: "playDates");

            migrationBuilder.DropIndex(
                name: "IX_playDates_UsersId",
                table: "playDates");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "playDates");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "playDates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
