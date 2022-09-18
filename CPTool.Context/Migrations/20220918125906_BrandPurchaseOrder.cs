using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class BrandPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "PurchaseOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_BrandId",
                table: "PurchaseOrders",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Brands_BrandId",
                table: "PurchaseOrders",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Brands_BrandId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_BrandId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "PurchaseOrders");
        }
    }
}
