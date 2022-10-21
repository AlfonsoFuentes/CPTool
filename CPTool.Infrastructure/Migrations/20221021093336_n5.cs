using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class n5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOs_MWOTypes_MWOTypeId",
                table: "MWOs");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems");

            migrationBuilder.AddColumn<string>(
                name: "TagNumber",
                table: "PipingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems",
                column: "eProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOs_MWOTypes_MWOTypeId",
                table: "MWOs",
                column: "MWOTypeId",
                principalTable: "MWOTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOs_MWOTypes_MWOTypeId",
                table: "MWOs");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems");

            migrationBuilder.DropColumn(
                name: "TagNumber",
                table: "PipingItems");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_ProcessConditions_eProcessConditionId",
                table: "EquipmentItems",
                column: "eProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOs_MWOTypes_MWOTypeId",
                table: "MWOs",
                column: "MWOTypeId",
                principalTable: "MWOTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");
        }
    }
}
