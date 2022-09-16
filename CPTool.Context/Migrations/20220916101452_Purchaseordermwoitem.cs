using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class Purchaseordermwoitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_MWOItems_MWOItemId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_MWOItemId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "MWOItemId",
                table: "PurchaseOrders");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderMWOItems",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    MWOItemId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderMWOItems", x => new { x.PurchaseOrderId, x.MWOItemId });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMWOItems_MWOItems_MWOItemId",
                        column: x => x.MWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMWOItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMWOItems_MWOItemId",
                table: "PurchaseOrderMWOItems",
                column: "MWOItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderMWOItems");

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
        }
    }
}
