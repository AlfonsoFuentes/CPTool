using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class VendorsCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxCodeLD",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TaxCodeLP",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "VendorCode",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "TaxCodeLDId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxCodeLPId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorCodeId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaxCodeLDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCodeLDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCodeLPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCodeLPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TaxCodeLDId",
                table: "Suppliers",
                column: "TaxCodeLDId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TaxCodeLPId",
                table: "Suppliers",
                column: "TaxCodeLPId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_VendorCodeId",
                table: "Suppliers",
                column: "VendorCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_TaxCodeLDs_TaxCodeLDId",
                table: "Suppliers",
                column: "TaxCodeLDId",
                principalTable: "TaxCodeLDs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_TaxCodeLPs_TaxCodeLPId",
                table: "Suppliers",
                column: "TaxCodeLPId",
                principalTable: "TaxCodeLPs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_VendorCodes_VendorCodeId",
                table: "Suppliers",
                column: "VendorCodeId",
                principalTable: "VendorCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_TaxCodeLDs_TaxCodeLDId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_TaxCodeLPs_TaxCodeLPId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_VendorCodes_VendorCodeId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "TaxCodeLDs");

            migrationBuilder.DropTable(
                name: "TaxCodeLPs");

            migrationBuilder.DropTable(
                name: "VendorCodes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_TaxCodeLDId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_TaxCodeLPId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_VendorCodeId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TaxCodeLDId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TaxCodeLPId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "VendorCodeId",
                table: "Suppliers");

            migrationBuilder.AddColumn<string>(
                name: "TaxCodeLD",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxCodeLP",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VendorCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
