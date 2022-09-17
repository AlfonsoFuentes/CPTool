using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class Downpaument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "DownPayments");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "DownPayments",
                newName: "DownPaymentAmount");

            migrationBuilder.AddColumn<double>(
                name: "PrizeCurrencyTax",
                table: "PurchaseOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "PurchaseOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrizeCurrency",
                table: "PurchaseOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RealDate",
                table: "DownPayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDueDate",
                table: "DownPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DownPaymentDueDate",
                table: "DownPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DownpaymentDescrption",
                table: "DownPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Incotherm",
                table: "DownPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerEmail",
                table: "DownPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "DownPayments",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrizeCurrencyTax",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrizeCurrency",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryDueDate",
                table: "DownPayments");

            migrationBuilder.DropColumn(
                name: "DownPaymentDueDate",
                table: "DownPayments");

            migrationBuilder.DropColumn(
                name: "DownpaymentDescrption",
                table: "DownPayments");

            migrationBuilder.DropColumn(
                name: "Incotherm",
                table: "DownPayments");

            migrationBuilder.DropColumn(
                name: "ManagerEmail",
                table: "DownPayments");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "DownPayments");

            migrationBuilder.RenameColumn(
                name: "DownPaymentAmount",
                table: "DownPayments",
                newName: "Amount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RealDate",
                table: "DownPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "DownPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
