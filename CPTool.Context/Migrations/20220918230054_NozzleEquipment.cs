using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class NozzleEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PipingItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_EquipmentItems_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId",
                principalTable: "EquipmentItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_InstrumentItems_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId",
                principalTable: "InstrumentItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_PipingItems_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId",
                principalTable: "PipingItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_EquipmentItems_EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_InstrumentItems_InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_PipingItems_PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "PipingItemId",
                table: "Nozzles");
        }
    }
}
