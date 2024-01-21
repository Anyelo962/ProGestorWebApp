using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProGestor.WebApplication.final.Migrations
{
    /// <inheritdoc />
    public partial class ModificacioTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "genderId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_genderId",
                table: "AspNetUsers",
                column: "genderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_genderId",
                table: "AspNetUsers",
                column: "genderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_genderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_genderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "genderId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
