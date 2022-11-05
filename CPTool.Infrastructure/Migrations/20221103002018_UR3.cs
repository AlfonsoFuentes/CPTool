using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class UR3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedBy",
                table: "UserRequirements");

            migrationBuilder.AddColumn<int>(
                name: "RequestedById",
                table: "UserRequirements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RequestedBys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedBys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRequirements_RequestedById",
                table: "UserRequirements",
                column: "RequestedById");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequirements_RequestedBys_RequestedById",
                table: "UserRequirements",
                column: "RequestedById",
                principalTable: "RequestedBys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequirements_RequestedBys_RequestedById",
                table: "UserRequirements");

            migrationBuilder.DropTable(
                name: "RequestedBys");

            migrationBuilder.DropIndex(
                name: "IX_UserRequirements_RequestedById",
                table: "UserRequirements");

            migrationBuilder.DropColumn(
                name: "RequestedById",
                table: "UserRequirements");

            migrationBuilder.AddColumn<string>(
                name: "RequestedBy",
                table: "UserRequirements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
