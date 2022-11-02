using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class Taks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Takss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MWOId = table.Column<int>(type: "int", nullable: true),
                    MWOItemId = table.Column<int>(type: "int", nullable: true),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    DownpaymentId = table.Column<int>(type: "int", nullable: true),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaksStatus = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Takss_DownPayments_DownpaymentId",
                        column: x => x.DownpaymentId,
                        principalTable: "DownPayments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Takss_MWOItems_MWOItemId",
                        column: x => x.MWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Takss_MWOs_MWOId",
                        column: x => x.MWOId,
                        principalTable: "MWOs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Takss_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Takss_DownpaymentId",
                table: "Takss",
                column: "DownpaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Takss_MWOId",
                table: "Takss",
                column: "MWOId");

            migrationBuilder.CreateIndex(
                name: "IX_Takss_MWOItemId",
                table: "Takss",
                column: "MWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Takss_PurchaseOrderId",
                table: "Takss",
                column: "PurchaseOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Takss");
        }
    }
}
