using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class DeleteVendorCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_VendorCodes_VendorCodeId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequirements_RequestedBys_RequestedById",
                table: "UserRequirements");

            migrationBuilder.DropTable(
                name: "RequestedBys");

            migrationBuilder.DropTable(
                name: "VendorCodes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_VendorCodeId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "VendorCodeId",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "RequestedByUserId",
                table: "UserRequirements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequirements_Users_RequestedById",
                table: "UserRequirements",
                column: "RequestedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequirements_Users_RequestedById",
                table: "UserRequirements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "RequestedByUserId",
                table: "UserRequirements");

            migrationBuilder.DropColumn(
                name: "VendorCode",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "VendorCodeId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestedBys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedBys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_VendorCodeId",
                table: "Suppliers",
                column: "VendorCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_VendorCodes_VendorCodeId",
                table: "Suppliers",
                column: "VendorCodeId",
                principalTable: "VendorCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequirements_RequestedBys_RequestedById",
                table: "UserRequirements",
                column: "RequestedById",
                principalTable: "RequestedBys",
                principalColumn: "Id");
        }
    }
}
