using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class IncludeAssignedPrize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<double>(
                name: "Assigned",
                table: "MWOItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders",
                column: "MWOId",
                principalTable: "MWOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "MWOItems");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_MWOs_MWOId",
                table: "PurchaseOrders",
                column: "MWOId",
                principalTable: "MWOs",
                principalColumn: "Id");
        }
    }
}
