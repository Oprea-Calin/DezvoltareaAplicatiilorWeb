using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComandaArticole",
                table: "ComandaArticole");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ComandaArticole",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "providerID",
                table: "Articole",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ComandaArticole_IdComanda_IdArticol",
                table: "ComandaArticole",
                columns: new[] { "IdComanda", "IdArticol" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComandaArticole",
                table: "ComandaArticole",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComandaArticole_Articole_IdArticol",
                table: "ComandaArticole");

            migrationBuilder.DropForeignKey(
                name: "FK_ComandaArticole_Comenzi_IdComanda",
                table: "ComandaArticole");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ComandaArticole_IdComanda_IdArticol",
                table: "ComandaArticole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComandaArticole",
                table: "ComandaArticole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ComandaArticole");

            migrationBuilder.DropColumn(
                name: "providerID",
                table: "Articole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComandaArticole",
                table: "ComandaArticole",
                columns: new[] { "IdComanda", "IdArticol" });

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
    }
}
