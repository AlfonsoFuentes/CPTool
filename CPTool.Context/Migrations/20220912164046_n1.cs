using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class n1 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "MWOItemId",
                table: "PurchaseOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_MWOItemId",
                table: "PurchaseOrders",
                column: "MWOItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_MWOItems_MWOItemId",
                table: "PurchaseOrders",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

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
                name: "FK_PurchaseOrders_MWOItems_MWOItemId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_MWOItemId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "MWOItemId",
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
