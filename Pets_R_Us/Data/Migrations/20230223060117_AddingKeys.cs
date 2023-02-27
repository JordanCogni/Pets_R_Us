using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets_R_Us.Data.Migrations
{
    public partial class AddingKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UsersId",
                table: "AspNetUsers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_playDates_UsersId",
                table: "AspNetUsers",
                column: "UsersId",
                principalTable: "playDates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_playDates_UsersId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UsersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "AspNetUsers");
        }
    }
}
