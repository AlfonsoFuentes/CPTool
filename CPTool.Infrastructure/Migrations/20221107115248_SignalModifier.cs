using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class SignalModifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modifier",
                table: "Signals");

            migrationBuilder.AlterColumn<int>(
                name: "SignalTypeId",
                table: "Signals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FieldLocationId",
                table: "Signals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SignalModifierId",
                table: "Signals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SignalModifier",
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
                    table.PrimaryKey("PK_SignalModifier", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signals_SignalModifierId",
                table: "Signals",
                column: "SignalModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signals_SignalModifier_SignalModifierId",
                table: "Signals",
                column: "SignalModifierId",
                principalTable: "SignalModifier",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signals_SignalModifier_SignalModifierId",
                table: "Signals");

            migrationBuilder.DropTable(
                name: "SignalModifier");

            migrationBuilder.DropIndex(
                name: "IX_Signals_SignalModifierId",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "SignalModifierId",
                table: "Signals");

            migrationBuilder.AlterColumn<int>(
                name: "SignalTypeId",
                table: "Signals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FieldLocationId",
                table: "Signals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modifier",
                table: "Signals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
