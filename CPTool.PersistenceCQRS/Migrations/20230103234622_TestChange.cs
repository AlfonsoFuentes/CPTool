using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class TestChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentTypeId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentTypeSubId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_EquipmentTypeId",
                table: "MWOItems",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_EquipmentTypeSubId",
                table: "MWOItems",
                column: "EquipmentTypeSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EquipmentTypeSubs_EquipmentTypeSubId",
                table: "MWOItems",
                column: "EquipmentTypeSubId",
                principalTable: "EquipmentTypeSubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EquipmentTypes_EquipmentTypeId",
                table: "MWOItems",
                column: "EquipmentTypeId",
                principalTable: "EquipmentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EquipmentTypeSubs_EquipmentTypeSubId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EquipmentTypes_EquipmentTypeId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_EquipmentTypeId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_EquipmentTypeSubId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "EquipmentTypeId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "EquipmentTypeSubId",
                table: "MWOItems");
        }
    }
}
