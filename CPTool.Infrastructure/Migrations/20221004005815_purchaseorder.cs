using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class purchaseorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<int>(
                name: "MWOId",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders",
                column: "MWOId",
                principalTable: "MWOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders");

            migrationBuilder.AlterColumn<int>(
                name: "MWOId",
                table: "PurchaseOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders",
                column: "MWOId",
                principalTable: "MWOs",
                principalColumn: "Id");
        }
    }
}
