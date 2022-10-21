using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class process : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems",
                column: "eProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems",
                column: "eProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");
        }
    }
}
