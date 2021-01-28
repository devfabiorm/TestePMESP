using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestePMESP.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitaryPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "ProductQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddColumn<int>(
                name: "ImportId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImportId",
                table: "Products",
                column: "ImportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Import_ImportId",
                table: "Products",
                column: "ImportId",
                principalTable: "Import",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Import_ImportId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Import");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImportId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImportId",
                table: "Products");

            migrationBuilder.AlterColumn<double>(
                name: "UnitaryPrice",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductQuantity",
                table: "Products",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
