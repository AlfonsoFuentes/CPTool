using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class propertypackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyPackageId",
                table: "ProcessFluids",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PropertyPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPackages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessFluids_PropertyPackageId",
                table: "ProcessFluids",
                column: "PropertyPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessFluids_PropertyPackages_PropertyPackageId",
                table: "ProcessFluids",
                column: "PropertyPackageId",
                principalTable: "PropertyPackages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessFluids_PropertyPackages_PropertyPackageId",
                table: "ProcessFluids");

            migrationBuilder.DropTable(
                name: "PropertyPackages");

            migrationBuilder.DropIndex(
                name: "IX_ProcessFluids_PropertyPackageId",
                table: "ProcessFluids");

            migrationBuilder.DropColumn(
                name: "PropertyPackageId",
                table: "ProcessFluids");
        }
    }
}
