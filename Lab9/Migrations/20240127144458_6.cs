using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            migrationBuilder.AddColumn<Guid>(
                name: "IdComanda",
                table: "Comenzi",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComandaArticole",
                table: "ComandaArticole",
                columns: new[] { "IdComanda", "IdArticol" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComandaArticole",
                table: "ComandaArticole");

            migrationBuilder.DropColumn(
                name: "IdComanda",
                table: "Comenzi");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ComandaArticole",
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
        }
    }
}
