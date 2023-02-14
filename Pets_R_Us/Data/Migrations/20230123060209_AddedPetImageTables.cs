using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pets_R_Us.Data.Migrations
{
    public partial class AddedPetImageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetImageTableId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PetImageTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageCaption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetImageTables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PetImageTableId",
                table: "AspNetUsers",
                column: "PetImageTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PetImageTables_PetImageTableId",
                table: "AspNetUsers",
                column: "PetImageTableId",
                principalTable: "PetImageTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PetImageTables_PetImageTableId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PetImageTables");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PetImageTableId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PetImageTableId",
                table: "AspNetUsers");
        }
    }
}
