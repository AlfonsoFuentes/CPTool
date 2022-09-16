using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class purchaseorderdetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrencyDate",
                table: "PurchaseOrders",
                newName: "POOrderingdDate");

            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "AlterationItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "AlterationItems");

            migrationBuilder.RenameColumn(
                name: "POOrderingdDate",
                table: "PurchaseOrders",
                newName: "CurrencyDate");
        }
    }
}
