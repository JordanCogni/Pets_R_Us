using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets_R_Us.Data.Migrations
{
    public partial class ChangingTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestingUserId",
                table: "playDates",
                newName: "ReceivingUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivingUserId",
                table: "playDates",
                newName: "RequestingUserId");
        }
    }
}
