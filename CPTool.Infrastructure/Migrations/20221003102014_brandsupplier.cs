using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class brandsupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMWOItems_MWOItems_MWOItemId",
                table: "PurchaseOrderMWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMWOItems_MWOItems_MWOItemId",
                table: "PurchaseOrderMWOItems",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMWOItems_MWOItems_MWOItemId",
                table: "PurchaseOrderMWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderMWOItems");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderMWOItems_MWOItems_MWOItemId",
                table: "PurchaseOrderMWOItems",
                column: "MWOItemId",
                principalTable: "MWOItems",
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
    }
}
