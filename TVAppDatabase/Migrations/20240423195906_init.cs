using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVAppDatabase.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tvadasok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Csatorna = table.Column<string>(type: "TEXT", nullable: false),
                    Musor = table.Column<string>(type: "TEXT", nullable: false),
                    Kezdet = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Hossz = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Mufaj = table.Column<string>(type: "TEXT", nullable: false),
                    Felvetel = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tvadasok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nezok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    TvadasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nezok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nezok_Tvadasok_TvadasId",
                        column: x => x.TvadasId,
                        principalTable: "Tvadasok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nezok_TvadasId",
                table: "Nezok",
                column: "TvadasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nezok");

            migrationBuilder.DropTable(
                name: "Tvadasok");
        }
    }
}
