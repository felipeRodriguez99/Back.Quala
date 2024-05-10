using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigrationQualaTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quala.Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quala.Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quala.Branches",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Identifications = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quala.Branches", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Quala.Branches_Quala.Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Quala.Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quala.Currencies",
                columns: new[] { "Id", "Abbreviation", "Description" },
                values: new object[,]
                {
                    { 1, "USD", "Dólar estadounidense" },
                    { 2, "EUR", "Euro" },
                    { 3, "COP", "Peso colombiano" },
                    { 4, "MXN", "Peso mexicano" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quala.Branches_CurrencyId",
                table: "Quala.Branches",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quala.Branches");

            migrationBuilder.DropTable(
                name: "Quala.Currencies");
        }
    }
}
