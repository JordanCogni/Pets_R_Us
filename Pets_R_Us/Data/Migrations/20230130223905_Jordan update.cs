using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets_R_Us.Data.Migrations
{
    public partial class Jordanupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PetImageTables_PetImageTableId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PetImageTableId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PetImageTables_PetImageTableId",
                table: "AspNetUsers",
                column: "PetImageTableId",
                principalTable: "PetImageTables",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PetImageTables_PetImageTableId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PetImageTableId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PetImageTables_PetImageTableId",
                table: "AspNetUsers",
                column: "PetImageTableId",
                principalTable: "PetImageTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
