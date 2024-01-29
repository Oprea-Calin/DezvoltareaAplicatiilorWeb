using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandaArticole_Articole_IdArticol",
                table: "ComandaArticole");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandaArticole_Comenzi_IdComanda",
                table: "ComandaArticole");

            migrationBuilder.UpdateData(
                table: "Comenzi",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comenzi",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaArticole_Articole_IdArticol",
                table: "ComandaArticole",
                column: "IdArticol",
                principalTable: "Articole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaArticole_Comenzi_IdComanda",
                table: "ComandaArticole",
                column: "IdComanda",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandaArticole_Articole_IdArticol",
                table: "ComandaArticole");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandaArticole_Comenzi_IdComanda",
                table: "ComandaArticole");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comenzi",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaArticole_Articole_IdArticol",
                table: "ComandaArticole",
                column: "IdArticol",
                principalTable: "Articole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComandaArticole_Comenzi_IdComanda",
                table: "ComandaArticole",
                column: "IdComanda",
                principalTable: "Comenzi",
                principalColumn: "Id");
        }
    }
}
