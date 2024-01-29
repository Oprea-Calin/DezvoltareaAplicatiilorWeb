using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class _13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comenzi",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Comenzi_UserId",
                table: "Comenzi",
                newName: "IX_Comenzi_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Users_UserID",
                table: "Comenzi",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Users_UserID",
                table: "Comenzi");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comenzi",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comenzi_UserID",
                table: "Comenzi",
                newName: "IX_Comenzi_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Users_UserId",
                table: "Comenzi",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
